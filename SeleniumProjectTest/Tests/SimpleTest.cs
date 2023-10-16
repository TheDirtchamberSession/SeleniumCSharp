
using TestProject1.utility;

namespace TestProject1.Tests
{
    public class SimpleTest:BaseTestHub
    {
        
        [Test]
        public void NavigateToGoogleAndCheckTitle()
        {
            driver.Navigate().GoToUrl("https://www.google.com");
            Thread.Sleep(3000);

        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}