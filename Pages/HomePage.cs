using OpenQA.Selenium;

namespace BuggyUITest.Pages
{
    public class HomePage : BasePage
    {

        public HomePage(IWebDriver webDriver) : base(webDriver)
        {

        }

        public void GoToBasePage()
        {
            var baseUrl = _configurationDriver.BuggyHomePageUrl;
            goToPage(baseUrl);
        }

        public IWebElement btnRegister() => _webDriver.FindElement(By.CssSelector(@"a[href='/register']"));

        public IWebElement textboxLogin() => _webDriver.FindElement(By.Name("login"));

        public IWebElement textboxPassword() => _webDriver.FindElement(By.Name("password"));

        public IWebElement btnLogin() => _webDriver.FindElement(By.CssSelector(@"button[class='btn btn-success']"));

        public bool waitLogin(string firstname)
        {
            string expect = "Hi, " + firstname;
            return FindElement(By.XPath($"//*[text()='{expect}']"), 10).Displayed;
        }

        public IWebElement loginFailMessage() => FindElement(By.CssSelector(@"span[class='label label-warning']"), 10);


        public bool isHomePage()
        {
            return FindElement(By.XPath("//*[text()='Popular Model']"), 10).Displayed;
        }

    }
}
