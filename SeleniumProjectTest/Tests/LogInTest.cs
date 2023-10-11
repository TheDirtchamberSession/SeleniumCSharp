using OpenQA.Selenium;
using TestProject1.Fun;
using TestProject1.utility;

namespace TestProject1.Tests;

public class LogInTest : BaseTest
{
    [Test]
    public void LogInValidAccountTest()
    {
  
        Console.WriteLine("Hello First Test");
        FunLogIn.LogInAccount(driver, wait);
        Thread.Sleep(2000);
        Console.WriteLine("-------------------- First Test Pass ----------------------");

    }
}