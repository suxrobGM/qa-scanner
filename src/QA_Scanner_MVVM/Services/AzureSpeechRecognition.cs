using System;
using System.Runtime.InteropServices;

namespace QA_Scanner_MVVM.Services
{
    public class AzureSpeechRecognition : ISpeechRecognitionService, IDisposable
    {
        private IntPtr _azureSpeechObject;        

        public string OutputText { get; private set; }       

        public AzureSpeechRecognition(string subscriptionKey, string serviceRegion)
        {
            _azureSpeechObject = CreateAzureSpeech(subscriptionKey, serviceRegion);
        }

        public void RecognizeSpeechFromMicrophone()
        {
            RecognizeFromMicrophone(_azureSpeechObject);          
            OutputText = GetOutputResult(_azureSpeechObject); 
        }

        public void RecognizeSpeechFromWavFile(string fileName)
        {
            RecognizeFromWavFile(_azureSpeechObject, fileName);
            OutputText = GetOutputResult(_azureSpeechObject);
        }

        public void Dispose()
        {
            if (_azureSpeechObject != IntPtr.Zero)
            {
                DisposeAzureSpeech(_azureSpeechObject);
                _azureSpeechObject = IntPtr.Zero;
            }
            GC.SuppressFinalize(this);
        }

        #region Dll Imports
        [DllImport("SpeechRecognitionCore.dll")]
        private static extern IntPtr CreateAzureSpeech(string subscriptionKey, string regionName);

        [DllImport("SpeechRecognitionCore.dll")]
        private static extern void DisposeAzureSpeech(IntPtr azureSpeechObj);

        [DllImport("SpeechRecognitionCore.dll")]
        private static extern void RecognizeFromMicrophone(IntPtr azureSpeechObj);

        [DllImport("SpeechRecognitionCore.dll")]
        private static extern void RecognizeFromWavFile(IntPtr azureSpeechObj, string fileName);

        [DllImport("SpeechRecognitionCore.dll", CharSet = CharSet.Ansi)]
        [return: MarshalAs(UnmanagedType.BStr)]
        private static extern string GetOutputResult(IntPtr azureSpeechObj);        
        #endregion
    }
}
