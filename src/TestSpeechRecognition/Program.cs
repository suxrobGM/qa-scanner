using Microsoft.CognitiveServices.Speech;
using Microsoft.CognitiveServices.Speech.Audio;
using NAudio.Wave;
using System;
using System.Threading.Tasks;

namespace TestSpeechRecognition
{
    class Program
    {
        private static WasapiLoopbackCapture _loopbackCapture;

        public static async Task RecognizeSpeechAsync()
        {
            // Creates an instance of a speech config with specified subscription key and service region.
            // Replace with your own subscription key and service region (e.g., "westus").
            var config = SpeechConfig.FromSubscription("e574db6949814dac8b86004e4c082a3b", "uksouth");

            // Creates a speech recognizer.
            using (var recognizer = new SpeechRecognizer(config))
            {
                Console.WriteLine("Say something...");

                // Starts speech recognition, and returns after a single utterance is recognized. The end of a
                // single utterance is determined by listening for silence at the end or until a maximum of 15
                // seconds of audio is processed.  The task returns the recognition text as result. 
                // Note: Since RecognizeOnceAsync() returns only a single utterance, it is suitable only for single
                // shot recognition like command or query. 
                // For long-running multi-utterance recognition, use StartContinuousRecognitionAsync() instead.
                var result = await recognizer.RecognizeOnceAsync();

                // Checks result.
                if (result.Reason == ResultReason.RecognizedSpeech)
                {
                    Console.WriteLine($"We recognized: {result.Text}");
                }
                else if (result.Reason == ResultReason.NoMatch)
                {
                    Console.WriteLine($"NOMATCH: Speech could not be recognized.");
                }
                else if (result.Reason == ResultReason.Canceled)
                {
                    var cancellation = CancellationDetails.FromResult(result);
                    Console.WriteLine($"CANCELED: Reason={cancellation.Reason}");

                    if (cancellation.Reason == CancellationReason.Error)
                    {
                        Console.WriteLine($"CANCELED: ErrorCode={cancellation.ErrorCode}");
                        Console.WriteLine($"CANCELED: ErrorDetails={cancellation.ErrorDetails}");
                        Console.WriteLine($"CANCELED: Did you update the subscription info?");
                    }
                }
            }
        }

        // Continuous speech recognition.
        public static async Task ContinuousRecognitionWithFileAsync()
        {
            string wavFilePath = "C:\\Users\\suxrobgm\\source\\repos\\QA_Scanner\\src\\TestSpeechRecognition\\bin\\Debug\\netcoreapp2.2\\system_recorded_audio.wav";

            // <recognitionContinuousWithFile>
            // Creates an instance of a speech config with specified subscription key and service region.
            // Replace with your own subscription key and service region (e.g., "westus").
            var config = SpeechConfig.FromSubscription("e574db6949814dac8b86004e4c082a3b", "uksouth");

            var stopRecognition = new TaskCompletionSource<int>();

            // Creates a speech recognizer using file as audio input.
            // Replace with your own audio file name.
            using (var audioInput = AudioConfig.FromWavFileInput(wavFilePath))
            {
                using (var recognizer = new SpeechRecognizer(config, audioInput))
                {
                    // Subscribes to events.
                    recognizer.Recognizing += (s, e) =>
                    {
                        Console.WriteLine($"RECOGNIZING: Text={e.Result.Text}");
                    };

                    recognizer.Recognized += (s, e) =>
                    {
                        if (e.Result.Reason == ResultReason.RecognizedSpeech)
                        {
                            Console.WriteLine($"RECOGNIZED: Text={e.Result.Text}");
                        }
                        else if (e.Result.Reason == ResultReason.NoMatch)
                        {
                            Console.WriteLine($"NOMATCH: Speech could not be recognized.");
                        }
                    };

                    recognizer.Canceled += (s, e) =>
                    {
                        Console.WriteLine($"CANCELED: Reason={e.Reason}");

                        if (e.Reason == CancellationReason.Error)
                        {
                            Console.WriteLine($"CANCELED: ErrorCode={e.ErrorCode}");
                            Console.WriteLine($"CANCELED: ErrorDetails={e.ErrorDetails}");
                            Console.WriteLine($"CANCELED: Did you update the subscription info?");
                        }

                        stopRecognition.TrySetResult(0);
                    };

                    recognizer.SessionStarted += (s, e) =>
                    {
                        Console.WriteLine("\n    Session started event.");
                    };

                    recognizer.SessionStopped += (s, e) =>
                    {
                        Console.WriteLine("\n    Session stopped event.");
                        Console.WriteLine("\nStop recognition.");
                        stopRecognition.TrySetResult(0);
                    };

                    // Starts continuous recognition. Uses StopContinuousRecognitionAsync() to stop recognition.
                    await recognizer.StartContinuousRecognitionAsync().ConfigureAwait(false);

                    // Waits for completion.
                    // Use Task.WaitAny to keep the task rooted.
                    Task.WaitAny(new[] { stopRecognition.Task });

                    // Stops recognition.
                    await recognizer.StopContinuousRecognitionAsync().ConfigureAwait(false);
                }
            }
            // </recognitionContinuousWithFile>
        }

        public static void StartCapturingLoopback()
        {
            string outputFilePath = "system_recorded_audio.wav";

            _loopbackCapture = new WasapiLoopbackCapture();
            var recordedAudioWriter = new WaveFileWriter(outputFilePath, _loopbackCapture.WaveFormat);

            _loopbackCapture.DataAvailable += (o, e) =>
            {
                recordedAudioWriter.Write(e.Buffer, 0, e.BytesRecorded);
            };
            _loopbackCapture.RecordingStopped += (o, e) =>
            {
                recordedAudioWriter.Dispose();
                recordedAudioWriter = null;
                _loopbackCapture.Dispose();
            };

            _loopbackCapture.StartRecording();
        }

        public static void StopCapturingLoopback()
        {
            _loopbackCapture.StopRecording();
        }

        static void Main()
        {
            //StartCapturingLoopback();
            //RecognizeSpeechAsync().Wait();
            ContinuousRecognitionWithFileAsync().Wait();
            Console.WriteLine("Please press a key to continue.");
            Console.ReadKey();
            //StopCapturingLoopback();
            Console.ReadLine();
        }
    }
}
