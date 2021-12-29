using FrameworkTests.Utilites;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkTests.Pages
{
    public class LoginPage : PageFactoryBase
    {
        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        [FindsBy(How = How.CssSelector, Using = "div.col-mid > a")]
        private IWebElement _logInMenuButton;

        [FindsBy(How = How.CssSelector, Using = "input[type=text]")]
        private IWebElement _inputEmail;

        [FindsBy(How = How.CssSelector, Using = "input[type=password]")]
        private IWebElement _inputPassword;

        [FindsBy(How = How.CssSelector, Using = "input[type=submit]")]
        private IWebElement _logInButton;

        public MainPage Login()
        {
            _logInMenuButton.Click();
            _inputEmail.SendKeys("testingepam@rambler.ru");
            _inputPassword.SendKeys("AdminAdmin321");
            _logInButton.Click();

            Log.Info("Logged in");

            return new MainPage(Driver);
        }        
    }
}
