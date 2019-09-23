using System;
using System.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDMTAutomation.DataEntities;

namespace TDMTAutomation
{
    [TestClass]
    public class AutomationTests : BaseTest
    {
        [TestInitialize]
        public void Setup()
        {
            SetUp();
        }


        [DeploymentItem(@"TestData", "TestData")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\TestData\\TestDataAccess.xml", "Common", DataAccessMethod.Sequential)]
        [TestMethod]
        public void LaunchingTheApplication()
        {
            CommonInput objInput = new CommonInput(TestContext.DataRow);


        }

        [TestCleanup]
        public void Teardown()
        {
            //TearDown();
            Driver.Quit();
            Driver.Dispose();
        }
    }
}
