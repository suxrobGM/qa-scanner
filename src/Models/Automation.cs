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

        public Automation(string username, string password)
        {
            _site = "http://moodle.samtuit.uz/login/index.php";
            _username = username;
            _password = password;
            _teacherPassword = "";

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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void GoToSubjectTestPage(string teacherPassword, string subjectUrl)
        {
            _teacherPassword = teacherPassword;
            _webDriver.Navigate().GoToUrl(subjectUrl);
        }

        public void AnswerToAllQuestions(Subject subject)
        {           
            var questionsList = _webDriver.FindElements(By.ClassName("qtext"));
            foreach (var question in questionsList)
            {
                var answer = subject.ResponseComputerNetwork(question.Text);
                if(CheckExistsElement($"//*[contains(text(), '{answer}')]"))
                {
                    var answerLabel = _webDriver.FindElement(By.XPath($"//*[contains(text(), '{answer}')]"));
                    string answerInputId = answerLabel.GetAttribute("for");
                    _webDriver.FindElement(By.Id(answerInputId)).Click();
                }               
            }
        }

        private bool CheckExistsElement(string xpath)
        {
            try
            {
                _webDriver.FindElement(By.XPath(xpath));
            }
            catch (NoSuchElementException)
            {
                return false;                
            }

            return true;
        }

        public void Test_GotoUrl(string url)
        {
            _webDriver.Navigate().GoToUrl(url);
        }
    }
}
