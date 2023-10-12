using OpenQA.Selenium;

namespace TestProject1.POM;

public abstract class LogInPageObject
{
    public static By UserNameField => By.Id("username");
    public static By UserPasswordField => By.Id("password");
    public static By LogInButton => By.Id("LoginEtsButton");

}