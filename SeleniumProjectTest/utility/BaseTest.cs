using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
namespace TestProject1.utility;

public class BaseTest
{
    protected WebDriver driver;
    public WebDriverWait wait;
    private string baseURL;
    private VideoRecorder recorder;
    protected Dictionary<string, string> EnvData;
    
    [SetUp]
    public void StartBrowser()
    {
        //Set Up
        var options = new ChromeOptions();
        options.AddArgument("--headless=new");
        driver = new ChromeDriver();
        wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
        baseURL = "https://www.saucedemo.com/";
        driver.Navigate().GoToUrl(baseURL);
        driver.Manage().Window.Maximize();
        // // Load the .env file for every test
        EnvData = EnvReader.Load(".env");
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