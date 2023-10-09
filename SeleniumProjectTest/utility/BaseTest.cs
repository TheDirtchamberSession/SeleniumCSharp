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

        
    [SetUp]
    public void StartBrowser()
    {
        var options = new ChromeOptions();
        options.AddArgument("--headless=new");
        driver = new ChromeDriver();
        wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
        baseURL = "https://www.beograd.rs/";
        driver.Navigate().GoToUrl(baseURL);
        driver.Manage().Window.Maximize();
        // Start recording
        recorder = new VideoRecorder();
        Directory.CreateDirectory("./"); // Ensure the directory exists
        recorder.StartRecording(Path.Combine("./", $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:yyyyMMdd_HHmmss}.mp4"));
    }
        
    [TearDown]
    public void CloseBrowser()
    {
        if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
        {
            var screenshot = ((ITakesScreenshot)driver).GetScreenshot();
                
            // Ensure the directory exists
            Directory.CreateDirectory("./");
                
            var screenshotFileName = Path.Combine("./", $"{TestContext.CurrentContext.Test.Name}_{DateTime.Now:yyyyMMdd_HHmmss}.png");
            screenshot.SaveAsFile(screenshotFileName, ScreenshotImageFormat.Png);
            Console.WriteLine($"Screenshot saved to: {screenshotFileName}");
        }
        
        driver.Quit();
        // Stop recording
        recorder.StopRecording();
        
        // Print ffmpeg error logs if any
        Console.WriteLine(recorder.GetErrorLog());
    }
}