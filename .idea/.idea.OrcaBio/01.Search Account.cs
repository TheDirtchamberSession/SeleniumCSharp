using System;
using NUnit.Framework;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Sorting
{
    [TestClass]
    public class Search
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;

        WebDriverWait wait;


        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "https://partnerportaluat.orangesoda.com/";
            verificationErrors = new StringBuilder();
            wait = new WebDriverWait(driver, new TimeSpan(0, 0, 30));
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("", verificationErrors.ToString());
        }


        [Test]
        public void Search_Account_Results()
        {
            driver.Navigate().GoToUrl(baseURL + "/");

            WaitAndSendKeys(By.Id("password"), "nocnicar121");
            waitAndClear(By.Id("username"));
            WaitAndSendKeys(By.Id("username"), "srdjan.sljanic@tnation.eu");
            WaitAndClick(By.XPath("//div[@id='wrapper']/section/div/div[2]/div[2]/div/div/form/div/button"));
            WaitAndClick(By.LinkText("Reports"));
            WaitAndClick(By.XPath("//div[2]/a/div/h3"));



            // Provera "Search" funkcije //

            waitAndClear(By.Id("PPCPerformance"));
            WaitAndSendKeys(By.Id("PPCPerformance"), "Team Honda");
            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.XPath(".//*[@id='wrapper']/section/div/div/div[2]/div/h1/div")));
           

            bool SearchFunctionValid = true;

            IWebElement SearchFunctionTabe = wait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='datasetTable-tbody-id']")));
            ReadOnlyCollection<IWebElement> list = SearchFunctionTabe.FindElements(By.TagName("tr"));


            foreach (IWebElement row in list)
            {


                if (!row.FindElements(By.TagName("td"))[0].Text.Contains("Team Honda"))
                    SearchFunctionValid = false;
            }

            NUnit.Framework.Assert.IsTrue(SearchFunctionValid, "Filter doesn't work");

            

            
        }

       
     


        public void WaitAndClick(By selector)
        {
            wait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(selector)).Click();

        }


        public void WaitAndSendKeys(By selector, string text)
        {
            wait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(selector)).SendKeys(text);
        }


        public void waitAndClear(By selector)
        {
            wait.Until<IWebElement>(ExpectedConditions.ElementIsVisible(selector)).Clear();


        }

      
        }

    }





