using System.IO;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Prism.Commands;
using Prism.Mvvm;
using QA_Scanner_MVVM.Services;
using System.Windows.Threading;
using System;

namespace QA_Scanner_MVVM.ViewModels
{
    public class SpeechRecognitionViewModel : BindableBase
    {
        private string _resultText;
        private string _recordingStatus;
        private string _recognizingStatus;        
        private string _selectedWavFile;
        private DateTime _recordingTimer;
        private LoopbackRecord _loopbackRecord;
        private DispatcherTimer _timer;

        public string ResultText { get => _resultText; set { SetProperty(ref _resultText, value); } }
        public string RecordingStatus { get => _recordingStatus; set { SetProperty(ref _recordingStatus, value); } }
        public string RecognizingStatus { get => _recognizingStatus; set { SetProperty(ref _recognizingStatus, value); } }
        public string SelectedWavFile { get => _selectedWavFile; set { SetProperty(ref _selectedWavFile, value); RecognizeCommand.RaiseCanExecuteChanged(); } }
        public DateTime RecordingTimer { get => _recordingTimer; set { SetProperty(ref _recordingTimer, value); } }
        public ObservableCollection<string> WavFiles { get; }
        public DelegateCommand StartCommand { get; }
        public DelegateCommand StopCommand { get; }
        public DelegateCommand RecognizeCommand { get; }

        public SpeechRecognitionViewModel()
        {
            if (!Directory.Exists("LoopbackRecords"))         
                Directory.CreateDirectory("LoopbackRecords");           

            ResultText = "";         
            WavFiles = new ObservableCollection<string>();
            
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1.0),
            };
            _timer.Tick += (o, e) =>
            {
                RecordingTimer = RecordingTimer.AddSeconds(1.0);
            };
            UpdateWavFilesList();

            StartCommand = new DelegateCommand(() =>
            {
                StartCommand.IsActive = true;
                StopCommand.IsActive = false;
                StopCommand.RaiseCanExecuteChanged();
                StartCommand.RaiseCanExecuteChanged();

                Task.Run(() =>
                {
                    _loopbackRecord = new LoopbackRecord();
                    RecordingTimer = new DateTime();
                    var fileName = $"LoopbackRecords\\audio_{WavFiles.Count + 1}.wav";
                    RecordingStatus = $"Recording audio in file: {fileName}";
                    _timer.Start();
                    _loopbackRecord.StartRecordingLoopback(fileName);
                });     
                
            }, CanExecuteStartCommand);

            StopCommand = new DelegateCommand(() =>
            {
                StartCommand.IsActive = false;
                StopCommand.IsActive = true;
                StartCommand.RaiseCanExecuteChanged();
                StopCommand.RaiseCanExecuteChanged();
                _timer.Stop();
                _loopbackRecord.StopRecordingLoopback();
                UpdateWavFilesList();
                RecordingStatus = $"Stopped recording audio";

            }, CanExecuteStopCommand);

            RecognizeCommand = new DelegateCommand(() =>
            {
                Task.Run(() =>
                {
                    using (var speechRecognition = new AzureSpeechRecognition("e574db6949814dac8b86004e4c082a3b", "uksouth"))
                    {
                        var selectedWavFile = SelectedWavFile;
                        RecognizingStatus = $"Recognizing speech from {selectedWavFile}";
                        RecognizeCommand.IsActive = true;
                        RecognizeCommand.RaiseCanExecuteChanged();
                        speechRecognition.RecognizeSpeechFromWavFile(selectedWavFile);
                        ResultText += speechRecognition.OutputText + "\n\n";
                        RecognizeCommand.IsActive = false;
                        RecognizeCommand.RaiseCanExecuteChanged();
                        RecognizingStatus = $"Recognized! file {selectedWavFile}";
                    }
                });
                
            }, CanExecuteRecognizeCommand);
        }       

        private bool CanExecuteStartCommand() => !StartCommand.IsActive;
        private bool CanExecuteStopCommand() => StartCommand.IsActive;
        private bool CanExecuteRecognizeCommand() => !RecognizeCommand.IsActive && !string.IsNullOrEmpty(SelectedWavFile);
        private void UpdateWavFilesList()
        {
            foreach (var wavFileName in Directory.EnumerateFiles("LoopbackRecords"))
            {
                if (wavFileName.Contains(".wav") && !WavFiles.Contains(wavFileName))
                {
                    WavFiles.Add(wavFileName);
                }
            }
        }
    }
}
