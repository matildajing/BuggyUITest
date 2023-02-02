using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using TestApplication.UiTests.Drivers;

namespace BuggyUITest.Pages
{
    public class BasePage
    {
        protected readonly IWebDriver _webDriver;
        protected readonly ConfigurationDriver _configurationDriver;

        public BasePage(IWebDriver webDriver)
        {
            if (webDriver.GetType().Name == "ChromeDriver")
            {
                _configurationDriver = new ConfigurationDriver();
                ChromeDriver driver = (ChromeDriver)webDriver;
                _webDriver = driver;
            }
        }

        public void goToPage(string pageUrl)
        {
            _webDriver.Manage().Window.Maximize();
            _webDriver.Navigate().GoToUrl($"{pageUrl}/");
        }

        public IWebElement FindElement(By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return _webDriver.FindElement(by);
        }
    }
}
