using TechTalk.SpecFlow;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

public class TestingDriver
{
    private IWebDriver driver;
    private ScenarioContext context;

    public TestingDriver(ScenarioContext context)
    {
        this.context = context;
    }

    public IWebDriver Init()
    {

        driver = new ChromeDriver();
        return driver;
    }

    public void Cleanup()
    {
        driver.Close();
    }
}