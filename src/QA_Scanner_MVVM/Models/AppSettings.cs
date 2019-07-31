using System.IO;
using Newtonsoft.Json;

namespace QA_Scanner_MVVM.Models
{
    public class AppSettings
    {
        private string _selectedSubject;
        private bool _isAsynchronousFinding;
        private double _opacity;
        private string _username;
        private string _password;

        public string SelectedSubject
        {
            get => _selectedSubject;
            set
            {
                _selectedSubject = value;
                SerializeToFile();
            }
        }
        public bool IsAsynchronousFinding {
            get => _isAsynchronousFinding;
            set
            {
                _isAsynchronousFinding = value;
                SerializeToFile();
            }
        }
        public double Opacity
        {
            get => _opacity;
            set
            {
                _opacity = value;
                SerializeToFile();
            }
        }
        public string Username
        {
            get => _username;
            set
            {
                _username = value;
                SerializeToFile();
            }
        }
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                SerializeToFile();
            }
        }

        public void SerializeToFile() => File.WriteAllText(App.SettingsFile, this.ToJson());
        public string ToJson() => JsonConvert.SerializeObject(this, Formatting.Indented);
        public static AppSettings FromJson(string json) => JsonConvert.DeserializeObject<AppSettings>(json);
        public static AppSettings FromJsonFile() => JsonConvert.DeserializeObject<AppSettings>(File.ReadAllText(App.SettingsFile));
    }
}
