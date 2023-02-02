using BuggyUITest.Pages;
using BuggyUITest.Support;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace BuggyUITest.Steps
{
    [Binding]
    public class RegisterSteps : BaseStep
    {

        protected string username;
        protected string _firstname;

        [Given(@"I am on the base page of buggy")]
        public void GivenIAmOnTheHomePage()
        {
            homePage.GoToBasePage();
        }

        [When(@"I click Register button")]
        public void WhenISearchFor() => homePage.btnRegister().Click();

        [Then(@"I should login properly")]
        public void ThenCheckHi()
        {
            Assert.AreEqual(homePage.waitLogin(_firstname), true);
            TakeScreenShot.takeScreenShot(_driver, this);
        }


        [When(@"I login with just username and (.*)")]
        public void ThenLogin(string password)
        {
            homePage.textboxLogin().SendKeys(username);
            homePage.textboxPassword().SendKeys(password);
            homePage.btnLogin().Submit();

        }

        [Then(@"I should be directed to home page")]
        public void ThenRedirectToHomePage()
        {
            TakeScreenShot.takeScreenShot(_driver, this);
            Assert.AreEqual(homePage.isHomePage(), true);
        }

        [Then(@"I should get error message in home page: (.*)")]
        public void ThenGetHome(string message)
        {
            TakeScreenShot.takeScreenShot(_driver, this);
            Assert.AreEqual(homePage.loginFailMessage().Text, message);
        }

        //Register page

        [Then(@"I should see the page contain Register with Buggy Cars Rating")]
        public void ThenIShouldSeeTitle()
        {
            TakeScreenShot.takeScreenShot(_driver, this);
            Assert.AreEqual(registerPage.waitPageLoad(), true);
        }

        [Then(@"I could not click Register button as no info is filled")]
        public void ThenRegisterButtonStatus()
        {
            Assert.AreEqual(registerPage.btnRegisterDown().Enabled, false);
        }

        [When(@"I fill fields Login: (.*), First Name: (.*), Last Name: (.*), Password: (.*)")]
        public void WhenFillRegistrationFields(string loginName, string firstName, string lastName, string password)
        {
            username = loginName + StringConvert.GetRandomString(10, true, true, true, false, null);
            _firstname = firstName + StringConvert.GetRandomString(10, true, true, true, false, null);

            registerPage.fillRegisterFields(username, _firstname, lastName, password, password);
        }

        [Then(@"I could click Register button")]
        public void ThenRegisterButtonStatusTrue()
        {
            Assert.AreEqual(registerPage.btnRegisterDown().Enabled, true);
        }

        [When(@"I click Register submit button")]
        public void WhenIClickRegister()
        {
            registerPage.btnRegisterDown().Click();

        }

        [Then(@"I should get success message: (.*)")]
        public void ThenGetRegisterSuccessMessage(string message)
        {
            Assert.AreEqual(registerPage.messageSuccess().Text, message);
            TakeScreenShot.takeScreenShot(_driver, this);
        }
        

        //register page 
        [Given(@"I am on the register page")]
        public void GivenIAmOnTheRegisterPage()
        {
            registerPage = new RegisterPage(_driver);
            registerPage.GoToRegisterPage();
        }

        [When(@"I fill all fields except with improper password requirement, length: (.*), hasUpper: (.*), hasLower: (.*), hasSpecial: (.*)")]
        public void WhenFillRegistrationFieldsRightExceptPassword(int length, string hasUpper, string hasLower, string hasSpecial)
        {
            username = "auto_test" + StringConvert.GetRandomString(10, true, true, true, false, null);
            _firstname = "firstname_" + StringConvert.GetRandomString(10, true, true, true, false, null);

            string password = StringConvert.GetRandomString(
                length, true,
                StringConvert.StringToBool(hasLower),
                StringConvert.StringToBool(hasUpper), StringConvert.StringToBool(hasSpecial), null);

            registerPage.fillRegisterFields(username, _firstname, "last_name", password, password);

        }

        [Then(@"I should get error message: (.*)")]
        public void ThenGetRegisterErrorMessage(string message)
        {
            System.Console.WriteLine("error message is: {0}", registerPage.messageFail().Text);
            TakeScreenShot.takeScreenShot(_driver, this);
            Assert.AreEqual(registerPage.messageFail().Text, message);
        }

        [When(@"I fill all fields except with existed user_name: (.*)")]
        public void WhenFillExistedUsername(string username)
        {

            string password = StringConvert.GetRandomString(10, true, true, true, true, null);

            registerPage.fillRegisterFields(username, "first_name", "last_name", password, password);

        }

        
        [When(@"I click Cancel button")]
        public void WhenClickCancel()
        {
            registerPage.btnCancel().Click();

        }


    }
}


