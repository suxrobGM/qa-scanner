using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace QA_Scanner_MVVM.Services
{
    public class AzureSpeechRecognition : ISpeechRecognitionService, IDisposable, INotifyPropertyChanged
    {
        private string _outputText;
        private readonly IntPtr _azureSpeechObject;        

        public string OutputText { get => _outputText; private set { _outputText = value; RaiseOnPropertyChanged(); } }       

        public AzureSpeechRecognition(string subscriptionKey, string serviceRegion)
        {
            _azureSpeechObject = CreateAzureSpeech(subscriptionKey, serviceRegion);
        }

        public void RecognizeSpeechFromMicrophone()
        {
            RecognizeFromMicrophone(_azureSpeechObject);
            OutputText = GetOutputResult(_azureSpeechObject);
        }

        public void Dispose()
        {
            if (_azureSpeechObject != null)
            {
                DisposeAzureSpeech(_azureSpeechObject);
            }
        }

        ~AzureSpeechRecognition()
        {
            Dispose();
        }

        #region Dll imports
        [DllImport("SpeechRecognitionCore.dll")]
        private static extern IntPtr CreateAzureSpeech(string subscriptionKey, string regionName);

        [DllImport("SpeechRecognitionCore.dll")]
        private static extern void DisposeAzureSpeech(IntPtr azureSpeechObj);

        [DllImport("SpeechRecognitionCore.dll")]
        private static extern void RecognizeFromMicrophone(IntPtr azureSpeechObj);

        [DllImport("SpeechRecognitionCore.dll")]
        private static extern void RecognizeFromWawFile(IntPtr azureSpeechObj,
                                                        string fileName,
                                                        bool saveToOutputFile = false,
                                                        string outputFileName = "transcript.txt"
                                                        );

        [DllImport("SpeechRecognitionCore.dll")]
        private static extern string GetOutputResult(IntPtr azureSpeechObj);
        #endregion

        #region INotifyPropertyChanged implements
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaiseOnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
