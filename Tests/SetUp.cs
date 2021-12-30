using FrameworkTests.Pages;
using NUnit.Framework;
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
    [SetUpFixture]
    public abstract class SetUp
    {
        public IWebDriver driver;

        [SetUp]
        public void InitBrowserAndLogin()
        {
            new DriverManager().SetUpDriver(new EdgeConfig());
            driver = new EdgeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            driver.Navigate().GoToUrl("https://libertex.fxclub.by/register");

            var loginPage = new LoginPage(driver);
            loginPage.Login();
        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
            driver = null;            
        }
    }
}
