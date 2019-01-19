using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace QA_Scanner.Models
{
    public class Automation
    {
        private string _site;
        private string _username;
        private string _password;
        private string _teacherPassword;
        private IWebDriver _webDriver;

        public Automation(string username, string password, string teacherPassword = null)
        {
            _site = "http://moodle.samtuit.uz/login/index.php";
            _username = username;
            _password = password;
            _teacherPassword = teacherPassword;

            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;
            _webDriver = new ChromeDriver(chromeDriverService, new ChromeOptions());
        }

        public void SessionLogin()
        {
            try
            {
                _webDriver.Navigate().GoToUrl(_site);
                var userNameField = _webDriver.FindElement(By.Id("username"));
                var userPasswordField = _webDriver.FindElement(By.Id("password"));
                var loginButton = _webDriver.FindElement(By.Id("loginbtn"));

                userNameField.SendKeys(_username);
                userPasswordField.SendKeys(_password);
                loginButton.Click();
            }
            catch (Exception)
            {
                throw new Exception();
            }
        }
    }
}
