using TestProject1.Fun;
using TestProject1.utility;

namespace TestProject1.Tests;

public class LogInTest : BaseTest
{
    [Test]
    public void LogInValidAccountTest()
    
    {
  
        Console.WriteLine("-----------------Hello First Test--------------------------");
        FunLogIn.LogInAccount(driver, wait);
        Console.WriteLine("-------------------- First Test Pass ----------------------");
        
    }
}