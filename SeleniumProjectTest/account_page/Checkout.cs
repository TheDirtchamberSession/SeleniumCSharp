
using TestProject1.Fun;
using TestProject1.POM;
using TestProject1.utility;

namespace TestProject1.account_page;

public class Checkout:BaseTest
{
    [Test]
    public void LogInValidAccountTest()
    {
        FunLogIn.LogInAccount(driver,wait);
        
    }
    
    [Test]
    public void LogInInvalidAccountTest()
    {
       
        driver.FindElement(LogInPageObject.EnglishSwitchBtn).Click();
    }
}