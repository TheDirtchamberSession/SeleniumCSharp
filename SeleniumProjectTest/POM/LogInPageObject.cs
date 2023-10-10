using OpenQA.Selenium;

namespace TestProject1.POM;

public abstract class LogInPageObject
{
    public static By UserNameField => By.Id("user-name");
    public static By UserPasswordField => By.Id("password");
    public static By LogInButton => By.Id("login-button");

}