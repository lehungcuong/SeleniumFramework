using System;
using System.IO;
using System.Reflection;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using SeleniumFramework.datatest;
using SeleniumFramework.util;

namespace SeleniumFramework.tests
{
    internal class BaseTest
    {
        public ExtentReports extent { get; set; }
        public ExtentV3HtmlReporter reporter { get; set; }
        public ExtentTest test { get; set; }

        [OneTimeSetUp]
        [Obsolete]
        public void initialize()
        {
            JsonReader.GetJsonDataSet();
            Util.InitBrowser("Chrome");
            extent = new ExtentReports();
            reporter = new ExtentV3HtmlReporter(Path.Combine(
                Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                "ExtentReports" + Util.GetTimestamp(DateTime.Now) + ".html"));
            reporter.Config.DocumentTitle = "Automation Testing Report";
            reporter.Config.ReportName = "Regression Testing";
            reporter.Config.Theme = Theme.Standard;
            extent.AttachReporter(reporter);
            extent.AddSystemInfo("Application Under Test", "nop Commerce Demo");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Machine", Environment.MachineName);
            extent.AddSystemInfo("OS", Environment.OSVersion.VersionString);
        }


        [OneTimeTearDown]
        public void cleanUp()
        {
            Util.CloseBrowser();
            extent.Flush();
        }
    }
}