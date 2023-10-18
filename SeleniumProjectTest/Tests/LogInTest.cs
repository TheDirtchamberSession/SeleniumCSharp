using TestProject1.Fun;
using TestProject1.utility;

namespace TestProject1.Tests;

public class LogInTest : BaseTest
{
    [Test]
    public void LogInValidAccountTest()
    {
  
        Console.WriteLine("Hello Orca First Test");
        FunLogIn.LogInAccount(driver, wait);
        Thread.Sleep(1000);
        Console.WriteLine("-------------------- First Orca Test Pass ----------------------");
        
    }
}