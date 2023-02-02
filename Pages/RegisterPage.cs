using OpenQA.Selenium;

namespace BuggyUITest.Pages
{
    public class RegisterPage : BasePage
    { 

        public RegisterPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public void GoToRegisterPage()
        {
            string registerUrl = _configurationDriver.RegisterPageUrl;
            goToPage(registerUrl);
        }

        public bool waitPageLoad() => FindElement(By.XPath("//*[text()='Register with Buggy Cars Rating']"), 10).Displayed;

        //Register button to submit info
        public IWebElement btnRegisterDown() => _webDriver.FindElement(By.CssSelector(@"button[class='btn btn-default']"));

        public IWebElement btnCancel() => _webDriver.FindElement(By.XPath("//*[text()='Cancel']"));

        public IWebElement textboxUsername() => _webDriver.FindElement(By.Id("username"));

        public IWebElement textboxFirstname() => _webDriver.FindElement(By.Id("firstName"));

        public IWebElement textboxLastname() => _webDriver.FindElement(By.Id("lastName"));

        public IWebElement textboxPassword() => _webDriver.FindElement(By.Id("password"));

        public IWebElement textboxConfirmPassword() => _webDriver.FindElement(By.Id("confirmPassword"));

        public IWebElement messageSuccess() => FindElement(By.CssSelector(@"div[class='result alert alert-success']"), 10);

        public IWebElement messageFail() => FindElement(By.CssSelector(@"div[class='result alert alert-danger']"), 10);
        

        public void fillRegisterFields(string username, string firstName, string lastName, string password, string confirmPassword)
        {
            System.Console.WriteLine("userName is {0}, password is {1}", username, password);
            this.textboxUsername().SendKeys(username);
            this.textboxFirstname().SendKeys(firstName);
            this.textboxLastname().SendKeys(lastName);
            this.textboxPassword().SendKeys(password);
            this.textboxConfirmPassword().SendKeys(confirmPassword);
        }
    }

}