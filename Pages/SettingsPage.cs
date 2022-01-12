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

        [FindsBy(How = How.CssSelector, Using = "span.create-account-btn.create-demo-btn.create-btn-lg.a-btn.a-btn-trans.active")]
        private IWebElement _demoAccountAddButton;

        [FindsBy(How = How.CssSelector, Using = "button.a-btn.a-btn-blue")]
        private IWebElement _createAccountButton;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"region-demo-accounts-list\"]/div/ul/li[2]")]
        private IWebElement _selectCreatedAccountButton;

        [FindsBy(How = How.CssSelector, Using = "div.close-account")]
        private IWebElement _deleteAccountButton;

        [FindsBy(How = How.CssSelector, Using = "div.a-btn.a-btn-blue.close-account")]
        private IWebElement _confirmClosingAccountButton;

        private readonly By _SMS = By.XPath("//*[@id=\"region-phone\"]/div/form/dl[2]/dt/label");
        private readonly By _newAccount = By.CssSelector("div.close-account");
        private readonly By _confirmedClosing = By.XPath("//*[@id=\"modal\"]/div/div[2]/p");

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

        public SettingsPage StartCreatingDemoAccount()
        {
            Thread.Sleep(2000);
            _demoAccountAddButton.Click();

            Log.Info("Demo account creating menu opened");

            return this;
        }

        public SettingsPage CreatingDemoAccount()
        {
            _createAccountButton.Click();

            Log.Info("Demo account created");

            return this;
        }

        public SettingsPage DeleteCreatedDemoAccount()
        {
            _selectCreatedAccountButton.Click();
            _deleteAccountButton.Click();

            Log.Info("Demo account wanted to be deleted");

            return this;
        }

        public SettingsPage ConfirmDeletingDemoAccount()
        {
            _confirmClosingAccountButton.Click();

            Log.Info("Demo account closing confirmed");

            return this;
        }

        public string GetPhoneChangedText()
        {
            Thread.Sleep(1000);
            var text = Driver.FindElement(_SMS);
            return text.Text;
        }

        public IWebElement GetCreatedAccount()
        {
            Thread.Sleep(3000);
            return Driver.FindElement(_newAccount);
        }

        public string GetClosingAccountText()
        {
            Thread.Sleep(3000);
            var text = Driver.FindElement(_confirmedClosing);
            return text.Text;
        }
    }
}
