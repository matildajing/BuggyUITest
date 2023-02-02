using BuggyUITest.Pages;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BuggyUITest.Steps
{
    public class BaseStep
    {
        protected IWebDriver _driver;
        protected readonly TestingDriver _tbDriver;
        protected HomePage homePage;
        protected RegisterPage registerPage;

        public BaseStep()
        {
            _tbDriver = (TestingDriver)ScenarioContext.Current["tbDriver"];
            _driver = _tbDriver.Init();

            homePage = new HomePage(_driver);
            registerPage = new RegisterPage(_driver);
        }
    }
}
