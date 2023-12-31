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
        
        //Set Up
        var options = new ChromeOptions();
        options.AddArguments("--no-sandbox", "--headless=new", "--disable-dev-shm-usage", "--disable-gpu",
            "--start-maximized");
        driver = new ChromeDriver();
        wait = new WebDriverWait(driver, new TimeSpan(0, 0, 10));
        baseURL = "https://traksys-test.orcabio.com/ts/";
        driver.Navigate().GoToUrl(baseURL);
        driver.Manage().Window.Maximize();
        // // Load the .env file for every test
        EnvData = EnvLoader.Load();
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