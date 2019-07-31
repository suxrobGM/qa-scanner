using System.Threading;
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace QA_Scanner_MVVM.Services
{
    public class LoopbackRecord
    {
        private readonly WasapiLoopbackCapture _loopbackCapture;

        public LoopbackRecord()
        {
            _loopbackCapture = new WasapiLoopbackCapture();
        }

        public void StartRecordingLoopback(string outputFileName)
        {
            var recordedAudioWriter = new WaveFileWriter(outputFileName, _loopbackCapture.WaveFormat);

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

        public void StartRecordingLoopback(string outputFileName, int duration)
        {
            var recordedAudioWriter = new WaveFileWriter(outputFileName, _loopbackCapture.WaveFormat);

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
            Thread.Sleep(duration);
            _loopbackCapture.StopRecording();
        }

        public void StopRecordingLoopback()
        {
            if (_loopbackCapture.CaptureState == CaptureState.Capturing)
            {
                _loopbackCapture.StopRecording();
            }
        }
    }
}
