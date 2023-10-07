using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
namespace TestProject1.utility
{
    public class BaseTest
    {
        protected WebDriver driver;
        public WebDriverWait wait;
        private string baseURL;
        
        [SetUp]
        public void StartBrowser()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
            baseURL = "https://www.beograd.rs/";
            driver.Navigate().GoToUrl(baseURL);
            driver.Manage().Window.Maximize();
        }
        
        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    }
}
    
