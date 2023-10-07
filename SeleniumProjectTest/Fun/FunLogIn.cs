using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestProject1.POM;

namespace TestProject1.Fun;

public class FunLogIn
{
    public static void clickOnEnglishBtn(WebDriver driver){
        
        driver.FindElement(LogInPageObject.EnglishSwitchBtn).Click();
        
}
    
    public static void LogInAccount (WebDriver driver, WebDriverWait wait){
        
        driver.FindElement(By.XPath("sadasdasd")).Click();
        driver.FindElement(LogInPageObject.EnglishSwitchBtn).SendKeys("sdasdasd");
        driver.FindElement(LogInPageObject.EnglishSwitchBtn).SendKeys("sdasdasd");
        wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("asd")));

    }
}