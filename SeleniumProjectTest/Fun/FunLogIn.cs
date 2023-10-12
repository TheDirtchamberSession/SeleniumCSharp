using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestProject1.POM;
using TestProject1.utility;

namespace TestProject1.Fun;

public static class FunLogIn
{
   
    public static void LogInAccount (WebDriver driver, WebDriverWait wait){
       
        var envData = EnvReader.Load(".env");

        driver.FindElement(LogInPageObject.UserNameField).SendKeys(envData["USERNAME"]);
        driver.FindElement(LogInPageObject.UserPasswordField).SendKeys(envData["PASSWORD"]);
        driver.FindElement(LogInPageObject.LogInButton).Click();
        wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("pagetitle")));

    }
}