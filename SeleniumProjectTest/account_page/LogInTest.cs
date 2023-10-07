using TestProject1.Fun;
using TestProject1.POM;
using TestProject1.utility;

namespace TestProject1.account_page;

public class LogInTest : BaseTest
{
    [Test]
    public void LogInValidAccountTest()
    {
        Console.WriteLine("Hello\nWorld");
        FunLogIn.clickOnEnglishBtn(driver);
        driver.FindElement(LogInPageObject.EnglishSwitchBtn).Click();
        Thread.Sleep(1000);
    }
}