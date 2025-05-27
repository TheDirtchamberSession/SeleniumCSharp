using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestProject1.POM;
using TestProject1.utility;

namespace TestProject1.Fun;

public class FunLogIn:BaseTest
{
    
    /// <summary>
    /// Performs login to the application using provided credentials from environment variables.
    /// </summary>
    /// <param name="driver">The WebDriver instance used to interact with the browser.</param>
    /// <param name="wait">The WebDriverWait instance used for handling explicit waits.</param>
    /// <remarks>
    /// This method:
    /// 1. Waits for the username field to become visible
    /// 2. Enters username and password from environment variables
    /// 3. Clicks the login button
    /// 4. Waits for the Products text to be visible, indicating successful login
    /// </remarks>

   
    public static void LogInAccount (WebDriver driver, WebDriverWait wait){
       
        //var envData = EnvReader.Load(".env");
        wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(LogInPageObject.UserNameField));
        driver.FindElement(LogInPageObject.UserNameField).SendKeys(EnvData["USERNAME"]);
        driver.FindElement(LogInPageObject.UserPasswordField).SendKeys(EnvData["PASSWORD"]);
        driver.FindElement(LogInPageObject.LogInButton).Click();
        wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//span[contains(text(),'Products')]")));
        
    }
}