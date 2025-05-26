
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
        Console.WriteLine("-------------------- First Test Pass ----------------------");
       
    }
}
