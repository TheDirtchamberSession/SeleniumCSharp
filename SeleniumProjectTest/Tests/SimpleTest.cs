using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace TestProject1.utility
{
    public class SimpleTest
    {
        private IWebDriver driver;
        private readonly string ZaleniumHubUrl = "http://localhost:4444/wd/hub";

        [SetUp]
        public void SetUp()
        {
            var chromeOptions = new ChromeOptions();
            
            var capabilities = new Dictionary<string, object>
            {
                { "zal:build", "ZaleniumTestBuild" },
                { "zal:name", "SimpleTest" },
                { "zal:tz", "Europe/Berlin" },
                { "zal:screenResolution", "1280x720" }
            };

            chromeOptions.AddAdditionalOption("zal:capabilities", capabilities);

            driver = new RemoteWebDriver(new Uri(ZaleniumHubUrl), chromeOptions);
        }

        [Test]
        public void NavigateToGoogleAndCheckTitle()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}