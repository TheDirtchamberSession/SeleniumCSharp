
using TestProject1.Fun;
using TestProject1.utility;
namespace TestProject1.Tests;
public class SimpleTest: BaseTestHub
{
    
    [Test]
    public void NavigateToWebAppAndLogIn()
    
    {
        Console.WriteLine("Hello First Test");
        FunLogIn.LogInAccount(driver, wait);
        Thread.Sleep(1000);
        Console.WriteLine("-------------------- First Test Pass ----------------------");
        Thread.Sleep(3000);
       
    }
}
