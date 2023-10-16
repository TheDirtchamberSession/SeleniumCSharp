using NUnit.Framework.Interfaces;
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
        private VideoRecorder recorder;
        public static Dictionary<string, string> EnvData;

        private readonly string SeleniumHubUrl = "http://localhost:4444/wd/hub"; // Pointing to Zalenium Grid

        [SetUp]
        public void StartBrowser()
        {
            var chromeOptions = new ChromeOptions();

            driver = new RemoteWebDriver(new Uri(SeleniumHubUrl), chromeOptions.ToCapabilities(),
                TimeSpan.FromSeconds(10));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10); // Set implicit wait

            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
            baseURL = "https://www.beograd.rs/:";
            driver.Navigate().GoToUrl(baseURL);
            driver.Manage().Window.Maximize();

            // Load the .env file for every test
            EnvData = EnvReader.Load(".env");

            // Start recording
            recorder = new VideoRecorder();
            Directory.CreateDirectory("./VideoTest"); // Ensure the directory exists
            recorder.StartRecording(Path.Combine("./VideoTest",
                $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:yyyyMMdd_HHmmss}.mp4"));
        }

        [TearDown]
        public void CloseBrowser()
        {
            string directoryPath;

            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                directoryPath = "./FailedTestScreenShot";
            }
            else if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
            {
                directoryPath = "./PassedTestScreenShot";
            }
            else
            {
                driver.Quit();
                return;
            }

            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var screenshotFileName = Path.Combine(directoryPath,
                $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
            screenshot.SaveAsFile(screenshotFileName, ScreenshotImageFormat.Png);
            Console.WriteLine($"Screenshot saved to: {screenshotFileName}");

            driver.Quit();

            // Stop recording
            recorder.StopRecording();

            // Print ffmpeg error logs if any
            Console.WriteLine(recorder.GetErrorLog());
        }
    }
}
