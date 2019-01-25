using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private string _teacherPassword;        
        private IWebDriver _webDriver;


        public BindingList<string> LogList { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public delegate string ResponseAlgorithm(string question);

        public Automation(string username = null, string password = null)
        {
            _site = "http://moodle.samtuit.uz/login/index.php";
            Username = username;
            Password = password;
            _teacherPassword = "";
            
            LogList = new BindingList<string>();
        }

        public void OpenChrome()
        {
            var chromeDriverService = ChromeDriverService.CreateDefaultService();
            chromeDriverService.HideCommandPromptWindow = true;
            _webDriver = new ChromeDriver(chromeDriverService, new ChromeOptions());
        }

        public void SessionLogin()
        {
            _webDriver.Navigate().GoToUrl(_site);
            var userNameField = _webDriver.FindElement(By.Id("username"));
            var userPasswordField = _webDriver.FindElement(By.Id("password"));
            var loginButton = _webDriver.FindElement(By.Id("loginbtn"));

            userNameField.SendKeys(Username);
            userPasswordField.SendKeys(Password);
            loginButton.Click();
        }

        public void GoToSubjectTestPage(string teacherPassword, string subjectUrl)
        {
            _teacherPassword = teacherPassword;
            _webDriver.Navigate().GoToUrl(subjectUrl);

            if (CheckExistsElement("//button[@type='submit'][text()='Начать тестирование']"))
                _webDriver.FindElement(By.XPath("//button[@type='submit'][text()='Начать тестирование']")).Click();
            else if (CheckExistsElement("//button[@type='submit'][text()='Пройти тест заново']"))
                _webDriver.FindElement(By.XPath("//button[@type='submit'][text()='Пройти тест заново']")).Click();


            var quizPassword = _webDriver.FindElement(By.Id("id_quizpassword"));
            quizPassword.SendKeys(teacherPassword);

            _webDriver.FindElement(By.Id("id_submitbutton")).Submit();
        }

        public void AnswerToAllQuestions(Subject subject, ResponseAlgorithm responseAlgorithm)
        {           
            var questionsList = _webDriver.FindElements(By.ClassName("qtext"));
            LogList.Add($"Catched {questionsList.Count} questions");

            int i = 1;
            foreach (var question in questionsList)
            {
                string answer = responseAlgorithm(question.Text);

                if(CheckExistsElement($"//*[contains(text(), '{answer}')]"))
                {
                    var answerLabel = _webDriver.FindElement(By.XPath($"//*[contains(text(), '{answer}')]"));
                    string answerInputId = answerLabel.GetAttribute("for");
                    _webDriver.FindElement(By.Id(answerInputId)).Click();
                    LogList.Add($"{i} question answered");
                }
                else
                {
                    LogList.Add($"{i} question not answered");
                }

                i++;
            }

            LogList.Add("Finished!");
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
