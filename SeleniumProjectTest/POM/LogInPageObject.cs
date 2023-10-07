using OpenQA.Selenium;

namespace TestProject1.POM;

public class LogInPageObject
{
    public static By EnglishSwitchBtn => By.XPath("//a[contains(text(),'ENG')]");
}