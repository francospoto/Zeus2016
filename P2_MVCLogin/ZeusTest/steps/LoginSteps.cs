using System;
using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ZeusTest.steps
{
    [Binding]
    public class LoginSteps
             
    {
        IWebDriver driver = new ChromeDriver(@"C:\Temp");

        [Given(@"I am on the login page")]
        public void GivenIAmOnTheLoginPage()
        {
            driver.Navigate().GoToUrl("http://localhost:65491/");
            var loginMenu = driver.FindElement(By.Id("loginLink"));
            loginMenu.Click();
        }
        
        [When(@"I fill in the form with")]
        public void WhenIFillInTheFormWith(Table table)
        {
            foreach (var row in table.Rows)
            {
                var texField = driver.FindElement(By.Id(row["field"]));
                texField.SendKeys(row["value"]);
            }

        }
        
        [When(@"I click ""(.*)""")]
        public void WhenIClick(string p0)
        {
            var loginButton = driver.FindElement(By.Id("btnIngresar"));
            loginButton.Click();
        }
        
        [Then(@"I should see ""(.*)""")]
        public void ThenIShouldSee(string p0)
        {
            ScenarioContext.Current.Pending();
            var loginMenu = driver.FindElement(By.Id("loginLink"));
        }
    }
}
