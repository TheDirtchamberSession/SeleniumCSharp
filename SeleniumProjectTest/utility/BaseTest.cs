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
            
            var options = new ChromeOptions();
            options.AddArgument("--headless=new");
            driver = new ChromeDriver(options);
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
    
