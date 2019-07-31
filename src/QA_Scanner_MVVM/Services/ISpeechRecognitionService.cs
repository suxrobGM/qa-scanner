using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Scanner_MVVM.Services
{
    public interface ISpeechRecognitionService
    {
        void RecognizeSpeechFromMicrophone();
        void RecognizeSpeechFromWavFile(string fileName);
    }
}
