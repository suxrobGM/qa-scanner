using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace QA_Scanner.Services
{
    public class SettingsXml : INotifyPropertyChanged
    {
        private readonly string _xmlFile;
        private string _selectedSubject;
        private bool _isAsynchronousFinding;
        private double _opacity;
        private string _username;
        private string _password;
        private XDocument _xDoc;

        #region Constructors
        public SettingsXml()
        {
            _xmlFile = "Settings.xml";
            if (!File.Exists(_xmlFile) || File.ReadAllText(_xmlFile) == String.Empty)
            {
                SetDefaultSettings();
            }
            _xDoc = XDocument.Load(_xmlFile);
        }

        public SettingsXml(string xmlFile)
        {
            _xmlFile = xmlFile;
            if (!File.Exists(_xmlFile) || File.ReadAllText(_xmlFile) == String.Empty)
            {
                SetDefaultSettings();
            }
            _xDoc = XDocument.Load(_xmlFile);
        }
        #endregion

        #region Properties
        public string SelectedSubject
        {
            get
            {
                _selectedSubject = _xDoc.Root.Element("SelectedSubject").Value;
                return _selectedSubject;
            }
            set
            {
                _selectedSubject = value;
                _xDoc.Root.Element("SelectedSubject").Value = value;
                _xDoc.Save(_xmlFile);
                RaisePropertyChanged("SelectedSubject");
            }
        }

        public bool IsAsynchronousFinding
        {
            get
            {
                _isAsynchronousFinding = Boolean.Parse(_xDoc.Root.Element("IsAsynchronousFinding").Value);
                return _isAsynchronousFinding;
            }
            set
            {
                _isAsynchronousFinding = value;
                _xDoc.Root.Element("IsAsynchronousFinding").Value = value.ToString();
                _xDoc.Save(_xmlFile);
                RaisePropertyChanged("IsAsynchronousFinding");
            }
        }

        public double Opacity
        {
            get
            {
                _opacity = Double.Parse(_xDoc.Root.Element("Opacity").Value);
                return _opacity;
            }
            set
            {
                _opacity = value;
                _xDoc.Root.Element("Opacity").Value = value.ToString();
                _xDoc.Save(_xmlFile);
                RaisePropertyChanged("Opacity");
            }
        }

        public string Username
        {
            get
            {
                _username = _xDoc.Root.Element("Username").Value;
                return _username;
            }
            set
            {
                _username = value;
                _xDoc.Root.Element("Username").Value = value;
                _xDoc.Save(_xmlFile);
                RaisePropertyChanged("Username");
            }
        }

        public string Password
        {
            get
            {
                _password = _xDoc.Root.Element("Password").Value;
                return _password;
            }
            set
            {
                _password = value;
                _xDoc.Root.Element("Password").Value = value;
                _xDoc.Save(_xmlFile);
                RaisePropertyChanged("Password");
            }
        }
        #endregion

        private void SetDefaultSettings()
        {
            _selectedSubject = "ManualTableMethod.docx";
            _isAsynchronousFinding = true;
            _opacity = 1.0;
            _username = "";
            _password = "";

            _xDoc = new XDocument(
                new XDeclaration("1.0.0.0", "utf-8", "yes"),
                new XElement("General_Settings",
                    new XElement("SelectedSubject", _selectedSubject),
                    new XElement("IsAsynchronousFinding", _isAsynchronousFinding),
                    new XElement("Opacity", _opacity),
                    new XElement("Username", _username),
                    new XElement("Password", _password)
                    )
                );

            _xDoc.Save(_xmlFile);
        }

        #region INotifyPropertyChanged interface implements
        public event PropertyChangedEventHandler PropertyChanged;
        public void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
