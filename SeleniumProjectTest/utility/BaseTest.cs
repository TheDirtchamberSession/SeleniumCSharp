using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
namespace TestProject1.utility;

public class BaseTest
{
    protected WebDriver driver;
    public WebDriverWait wait;
    private string baseURL;
    private VideoRecorder recorder;
    public static Dictionary<string, string> EnvData;
    

    [SetUp]
    public void StartBrowser()
    {
        // Set Up
        var options = new ChromeOptions();
        options.AddArguments("--no-sandbox", "--headless=new", "--disable-dev-shm-usage", "--disable-gpu",
            "--start-maximized");
        driver = new ChromeDriver();
        wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
        baseURL = "https://www.saucedemo.com/";
        driver.Navigate().GoToUrl(baseURL);
        driver.Manage().Window.Maximize();
        
        // Load the .env file for every test
        EnvData = EnvLoader.Load();
        
        // Create video directory in TestResults
        string videoPath = Path.Combine(
            Directory.GetCurrentDirectory(),
            "..",
            "..",
            "TestResults",
            "VideoTest"
        );
        
        Directory.CreateDirectory(videoPath);
        
        // Start recording
        recorder = new VideoRecorder();
        recorder.StartRecording(Path.Combine(videoPath,
            $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:yyyyMMdd_HHmmss}.mp4"));
    }
    
    [TearDown]
    public void CloseBrowser()
    {
        // Base directory for test results
        string baseTestResultsPath = Path.Combine(
            Directory.GetCurrentDirectory(),
            "..",
            "..",
            "TestResults"
        );

        // Early return if test status is neither Failed nor Passed
        if (TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Failed && 
            TestContext.CurrentContext.Result.Outcome.Status != TestStatus.Passed)
        {
            return;
        }

        string directoryPath;
        if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
        {
            directoryPath = Path.Combine(baseTestResultsPath, "FailedTestScreenShot");
        }
        else
        {
            directoryPath = Path.Combine(baseTestResultsPath, "PassedTestScreenShot");
        }

        try
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();

            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            var screenshotFileName = Path.Combine(directoryPath,
                $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
        
            // Using the non-deprecated method
            screenshot.SaveAsFile(screenshotFileName);
            Console.WriteLine($"Screenshot saved to: {screenshotFileName}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Failed to save screenshot: {ex.Message}");
        }
        finally
        {
            driver.Quit();
            // Stop recording
            recorder.StopRecording();
        
            // Print ffmpeg error logs if any
            Console.WriteLine(recorder.GetErrorLog());
        }
    }
}