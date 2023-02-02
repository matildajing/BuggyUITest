using System;
using System.IO;
using OpenQA.Selenium;

namespace BuggyUITest.Support
{
    public class TakeScreenShot
    {
        public TakeScreenShot()
        {
        }

        public static void takeScreenShot(IWebDriver driver, Object object1)
        {
            Screenshot screenshotFile = ((ITakesScreenshot)driver).GetScreenshot();
            string fileName = object1.GetType().ToString() + "_"+DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffffffZ")+ ".png";

            string path = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;

            string img_url = Path.Combine(path, fileName);

            screenshotFile.SaveAsFile(img_url, ScreenshotImageFormat.Png);

        }
    }
}
