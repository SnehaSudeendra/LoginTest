using System;
using System.IO;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;

namespace loginPage.BaseClass
{
    public class BaseTest
    {
        public IWebDriver driver;
        public static ExtentReports extent;
        public static ExtentSparkReporter sparkReporter;
        public static ExtentTest test;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "https://app-sygnal-dev-web.azurewebsites.net/auth/login";

            if (extent == null)
            {
                extent = new ExtentReports();
                sparkReporter = new ExtentSparkReporter("C:\\Users\\Sneha\\OneDrive\\Desktop\\Login\\Report.html");
                extent.AttachReporter(sparkReporter);
            }
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
            extent.Flush();
            driver.Dispose();
        }

    }
}
