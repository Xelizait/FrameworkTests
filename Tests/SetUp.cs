using FrameworkTests.Pages;
using FrameworkTests.Utilites;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace FrameworkTests.Tests
{
    [TestFixture]
    public class SetUp
    {
        [OneTimeSetUp]
        public void Startup()
        {
            Log.Info("Initialized");
        }

        [TearDown]
        public void TearDown()
        {
            var context = TestContext.CurrentContext;
            Log.Info($"Test '{context.Test.Name}' finished: {context.Result.Outcome.ToString()} ({context.Result.Message})");
            bool havePassed = context.Result.Outcome.Status == TestStatus.Passed;
            if (havePassed) return;

            ScreenshotHelper.TakeScreenshot();
        }

        [OneTimeTearDown]
        public void Close()
        {
            Log.Info("Close driver");
        }
    }
}
