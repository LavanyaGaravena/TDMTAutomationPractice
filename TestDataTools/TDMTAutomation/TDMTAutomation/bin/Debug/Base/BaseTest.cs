using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace TDMTAutomation
{
    public class BaseTest
    {
        #region Properties
        protected static IWebDriver Driver;
        protected static WebDriverWait Wait;
        //  private static Util.Screenshot ss;

        public static readonly string RootPath = @"C:\SampleAutomation";
        private static readonly string DownloadPath = RootPath + @"\Download";

        private int _timeout = 5;

        public static string mainWindow;
        public static string ge { get; set; }
        public static string user { get; set; }
        public static string pwd { get; set; }
        public static string browser { get; set; }
        public static string region { get; set; }
        public TestContext TestContext { get; set; }
        public static TestContext testContext;
        #endregion

        /// <summary>
        /// Initial setup for all test cases
        /// </summary>
        public void SetUp()
        {
            TestContext.WriteLine("Test started at: " + GetDate("MM/dd/yyyy HH:mm:ss"));

            //SetBrowserForWebDriver();
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            //ss = new Util.Screenshot();

            Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(_timeout));

            mainWindow = Driver.CurrentWindowHandle;

            testContext = TestContext;
        }

        /// <summary>
        /// Method called in test cleanup of all test cases
        /// </summary>
        public void TearDown()
        {
            //CustomReport report = new CustomReport();
            // TestContext.AddResultFile(ss.GetDocxPath());
            //  report.TestingReportAppend();
            Driver.Quit();
            Driver.Dispose();
            //TestContext.WriteLine("Test finished at: " + GetDate("MM/dd/yyyy HH:mm:ss"));

            // ss.CleanupResults();
        }

        public static void SetWaitTimeout(int timeoutInSecs)
        {
            Wait.Timeout = TimeSpan.FromSeconds(timeoutInSecs);
        }


        public static IWebDriver GetDriver()
        {
            return Driver;
        }

        public static WebDriverWait GetWait()
        {
            return Wait;
        }

        public static String GetMainWindow()
        {
            return mainWindow;
        }

        public static string GetDate(string dateFormat)
        {
            var date = DateTime.Now.ToString(dateFormat);
            return date;
        }
               
        public static void SwitchWindows(int expectedNumberOfWindows)
        {
            Wait.Until(Driver => Driver.WindowHandles.Count == expectedNumberOfWindows);

            for (int i = 0; i < Driver.WindowHandles.Count; i++)
            {
                if (Driver.WindowHandles[i] != mainWindow)
                {
                    Driver.SwitchTo().Window(Driver.WindowHandles[i]);
                }
            }
        }

        /// <summary>
        /// Capture screen and saves to docx file added to test results when test execution finishes
        /// </summary>
        public static void TakeScreenshot(IWebDriver driver)
        {
            // ss.TakeScreenshot(driver);
        }

        /// <summary>
        /// Gets user credentials and sets the environment and dispatch id attributes
        /// </summary>
        //private void GetCredentials()
        //{
        //    CreateTestDataFolder();

        //    ConfigFileReader fr = new ConfigFileReader(RootPath + @"\TestData\Properties.xlsx");

        //    SetEnvironment(fr);

        //    browser = fr.GetInfo("browser")[0].ToString();

        //    region = fr.GetInfo("region")[0].ToString();

        //    //SetDispatch(fr);

        //    try
        //    {
        //        user = fr.GetInfo("username")[0].ToString();
        //        pwd = fr.GetInfo("password")[0].ToString();
        //    }
        //    catch (ArgumentOutOfRangeException)
        //    {
        //        user = "ServiceGSDTest";
        //        pwd = "n2SCt9m7W3Yoi4L6R#";
        //    }
        //}

        /// <summary>
        /// Sets the environment according to MTM configuration. If not running
        /// from MTM, gets the env information from Properties.xlsx file.
        /// </summary>
        /// <param name="fr"></param>
        //private void SetEnvironment(ConfigFileReader fr)
        //{
        //    if (TestContext.Properties["__Tfs_TestConfigurationName__"] != null)
        //    {
        //        ge = TestContext.Properties["__Tfs_TestConfigurationName__"].ToString();
        //    }
        //    else
        //    {
        //        ge = fr.GetInfo("ge")[0].ToString();
        //    }
        //}



        /// <summary>
        /// Creates the TestData folder under the project's root path
        /// and copies the Properties.xlsx file into it only in case
        /// the file is not already in place.
        /// </summary>
        private void CreateTestDataFolder()
        {
            var testData = RootPath + @"\TestData";

            var properties = testData + @"\Properties.xlsx";

            try
            {
                Directory.CreateDirectory(testData);
            }
            catch (Exception e)
            {
                BaseTest.testContext.WriteLine(e.Message);
            }

            if (!File.Exists(properties))
            {
                try
                {
                    var sourceFile = "Properties.xlsx";

                    File.Copy(sourceFile, properties);
                }
                catch (Exception e)
                {
                    BaseTest.testContext.WriteLine(e.Message);
                }
            }
        }

        /// <summary>
        /// Sets the browser according to option selected in Properties.xlsx file
        /// </summary>
        //private void SetBrowserForWebDriver()
        //{
        //    switch (browser)
        //    {
        //        case "InternetExplorer":
        //            Driver = GetInternetExplorerDriver();
        //            break;
        //        case "GoogleChrome":
        //            Driver = GetChromeDriver();
        //            break;
        //        case "Firefox":
        //            Driver = GetFirefoxDriver();
        //            break;
        //        default:
        //            throw new Exception("Browser selected is invalid.");
        //    }
        //}

        private ChromeDriver GetChromeDriver()
        {
            var options = new ChromeOptions();
            options.AddUserProfilePreference("download.default_directory", DownloadPath);
            return new ChromeDriver(options);
        }

        //private InternetExplorerDriver GetInternetExplorerDriver()
        //{
        //    return new InternetExplorerDriver();
        //}

        //private FirefoxDriver GetFirefoxDriver()
        //{
        //    FirefoxProfile profile = new FirefoxProfile();
        //    profile.SetPreference("browser.download.dir", DownloadPath);
        //    return new FirefoxDriver();
        //}

        public static IJavaScriptExecutor JavaScript()
        {
            return (IJavaScriptExecutor)Driver;
        }
    }
}
