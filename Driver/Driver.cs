using FrameworkTests.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;


namespace FrameworkTests.Driver
{
    public static class Driver
    {
        private static IWebDriver _driver;

        public static IWebDriver GetDriver()
        {
            if (_driver is null)
            {
                //var browser = Configuration.Instance["Browser"];
                var browser = "Edge";

                switch (browser)
                {
                    case "Edge":
                        new DriverManager().SetUpDriver(new EdgeConfig());
                        _driver = new EdgeDriver();
                        break;
                    case "Firefox":
                        new DriverManager().SetUpDriver(new FirefoxConfig());
                        _driver = new FirefoxDriver();
                        break;
                    case "IE":
                        new DriverManager().SetUpDriver(new InternetExplorerConfig());
                        _driver = new InternetExplorerDriver();
                        break;
                    default:
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        _driver = new ChromeDriver();
                        break;
                }
            }

            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(15);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            _driver.Navigate().GoToUrl("https://libertex.fxclub.by/register");

            var loginPage = new LoginPage(_driver);
            loginPage.Login();

            return _driver;
        }

        public static void CloseDriver()
        {
            _driver.Close();
            _driver = null;
        }

    }
}
