using FrameworkTests.Utilites;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FrameworkTests.Pages
{
    public class SettingsPage : PageFactoryBase
    {
        public SettingsPage(IWebDriver driver) : base(driver)
        {

        }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"region-phone\"]/div/div[1]/span[2]")]
        private IWebElement _changePhoneButton;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"phone\"]")]
        private IWebElement _inputPhoneField;

        [FindsBy(How = How.CssSelector, Using = "input.a-btn.a-btn-pos")]
        private IWebElement _confirmChangingPhoneButton;

        private readonly By _SMS = By.XPath("//*[@id=\"region-phone\"]/div/form/dl[2]/dt/label");

        public SettingsPage ChangePhoneNumber()
        {
            _changePhoneButton.Click();
            _inputPhoneField.SendKeys("+375291234567");

            Log.Info("Phone number changed");

            return this;
        }

        public SettingsPage ConfirmChangingPhoneNumber()
        {
            _confirmChangingPhoneButton.Click();

            Log.Info("Phone number changing confirmed");

            return this;
        }

        public string GetPhoneChangedText()
        {
            Thread.Sleep(1000);
            var text = Driver.FindElement(_SMS);
            return text.Text;
        }
    }
}
