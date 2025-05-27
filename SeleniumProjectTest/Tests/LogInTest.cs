using TestProject1.Fun;
using TestProject1.utility;

namespace TestProject1.Tests;

/// <summary>
/// Test class for login functionality, inheriting from BaseTest.
/// </summary>
/// <remarks>
/// This class contains test methods to verify the login functionality of the application.
/// It uses the FunLogIn utility class for login operations.
/// </remarks>

public class LogInTest : BaseTest
{
    /// <summary>
    /// Tests the login process with valid account credentials.
    /// </summary>
    /// <remarks>
    /// This test method:
    /// 1. Attempts to log in using credentials handled by FunLogIn.LogInAccount
    /// </remarks>

    [Test]
    public void LogInValidAccountTest()
    
    {
        
        FunLogIn.LogInAccount(driver, wait); ;
        
    }
}