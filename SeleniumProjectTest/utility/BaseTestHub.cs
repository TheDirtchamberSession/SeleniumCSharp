using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
namespace TestProject1.utility
{
    public class BaseTestHub
    {
        protected WebDriver driver;
        public WebDriverWait wait;
        private string baseURL;
        // private VideoRecorder recorder;
        public static Dictionary<string, string> EnvData;
        private readonly string SeleniumHubUrl = "http://localhost:4444";

        [SetUp]
        public void StartBrowser()
        {
            var chromeOptions = new ChromeOptions();
            driver = new RemoteWebDriver(new Uri(SeleniumHubUrl), chromeOptions.ToCapabilities(), TimeSpan.FromSeconds(10));  // Set command timeout
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);  // Set implicit wait
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            baseURL = "https://www.saucedemo.com/";
            driver.Navigate().GoToUrl(baseURL);
            driver.Manage().Window.Maximize();

            // Load the .env file for every test
            EnvData = EnvLoader.Load();
            
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Quit();
        }
    }
}