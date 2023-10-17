
using OpenQA.Selenium;
using TestProject1.utility;

public class SimpleTest: BaseTestHub
{
    
    [Test]
    public void NavigateToGoogleAndCheckTitle()
    
    {
        driver.FindElement(By.Id("user-name")).SendKeys("standard_user");
        driver.FindElement(By.Id("password")).SendKeys("secret_sauce");
        driver.FindElement(By.Id("login-button")).Click();
        Thread.Sleep(3000);
       
    }
}
