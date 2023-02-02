
using TechTalk.SpecFlow;

namespace BuggyUITest.Drivers
{
    [Binding]
    public sealed class Testing
    {
        private TestingDriver tbDriver;

        [BeforeScenario]
        public void BeforeScenario()
        {
            tbDriver = new TestingDriver(ScenarioContext.Current);
            ScenarioContext.Current["tbDriver"] = tbDriver;
        }

        [AfterScenario]
        public void AfterScenario()
        {
            tbDriver.Cleanup();
        }
    }
}

