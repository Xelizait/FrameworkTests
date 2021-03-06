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
    public class MainPage : PageFactoryBase
    {
        public MainPage(IWebDriver driver) : base(driver)
        {

        }

        public WebDriverWait wait;

        public int balanceBefore;

        [FindsBy(How = How.CssSelector, Using = "div.chart-head-inner > a.a-btn.new-invest.growth")]
        private IWebElement _buyButton;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"sumInv\"]")]
        private IWebElement _selectPriceField;

        [FindsBy(How = How.XPath, Using = "(//li[@class=\"ui-menu-item selected\"])[1]")]
        private IWebElement _selectPriceDropmenu;

        [FindsBy(How = How.CssSelector, Using = "div.a-submit")]
        private IWebElement _confirmBuyingButton;

        [FindsBy(How = How.CssSelector, Using = "span.a-btn.a-btn-trans.a-invest-close")]
        private IWebElement _understandButton;

        [FindsBy(How = How.CssSelector, Using = "span.a-btn.a-btn-trans.close")]
        private IWebElement _notNowButton;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"region-header\"]/div[2]/div[1]/div[4]/a[1]")]
        private IWebElement _activeDealsButton;

        [FindsBy(How = How.CssSelector, Using = "span.ui-selectmenu-text.invest-account-select.demo-account-select.selected")]
        private IWebElement _selectAccountTypeDropmenu;

        [FindsBy(How = How.CssSelector, Using = "li.invest-account-select.real-account-select.ui-menu-item")]
        private IWebElement _selectAccountTypeButton;

        [FindsBy(How = How.XPath, Using = "/html/body/div[1]/div[3]/div[1]/div[1]/button")]
        private IWebElement _closeRealAccountInformationButton;

        [FindsBy(How = How.CssSelector, Using = "#region-header-profile > div > div:nth-child(2) > a:nth-child(5)")]
        private IWebElement _activeSessionsButton;

        [FindsBy(How = How.CssSelector, Using = "span.a-btn.a-btn-blue.logout")]
        private IWebElement _endAllSessionsButton;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"region-header\"]/div[2]/div[2]/div[3]/nav/span")]
        private IWebElement _submenuHover;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"region-header-profile\"]/div/div[2]/a[3]")]
        private IWebElement _settingsButton;

        [FindsBy(How = How.CssSelector, Using = "span.a-btn.a-btn-blue.confirm")]
        private IWebElement _confirmEndingAllSessionsButton;

        [FindsBy(How = How.CssSelector, Using = "span.favorite")]
        private IWebElement _addToFavouritesButton;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"region-header-profile\"]/div/div[1]/a")]
        private IWebElement _changeDemoAccountBalanceButton;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"amount\"]")]
        private IWebElement _inputBalanceIncreaseField;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"modal\"]/div/div[1]/form/div[2]/input")]
        private IWebElement _confirmChangingBalanceButton;

        [FindsBy(How = How.CssSelector, Using = "span.a-btn.a-btn-blue.cancel")]
        private IWebElement _okChangingBalanceButton;


        private readonly By _currency = By.XPath("//*[@id=\"region-active-investments\"]/div/div/div[5]/div/div[1]/div/div[1]/div[1]/div[1]/span[1]");
        private readonly By _value = By.XPath("//*[@id=\"region-active-investments\"]/div/div/div[5]/div/div[1]/div/div[1]/div[2]/div[2]/span[1]");
        private readonly By _accountType = By.CssSelector("span.ui-selectmenu-text.invest-account-select.real-account-select.selected");
        private readonly By _changedCurrency = By.XPath("//*[@id=\"region-chart-head\"]/div/div/div/div[1]/div[2]/div[1]/p/a");
        private readonly By _allSessionsClosed = By.XPath("//*[@id=\"modal\"]/div/div[3]/h3");
        private readonly By _favouritesCurrencies = By.CssSelector("div.favorites-instrument-view");
        private readonly By _currentBalance = By.XPath("//*[@id=\"region-balance\"]/div/div[2]/dl[1]/dd");

        public ActiveDealsPage OpenActiveDealsPage()
        {            
            _activeDealsButton.Click();

            Log.Info("Move to Active Deals page");

            return new ActiveDealsPage(Driver);
        }

        public SettingsPage OpenSettingsPage()
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(_submenuHover).Build().Perform();
            _settingsButton.Click();

            Log.Info("Move to Settings page");

            return new SettingsPage(Driver);
        }

        public MainPage StartCreatingBuyingDeal()
        {
            _buyButton.Click();

            Log.Info("BuyButton clicked");

            return this;
        }

        public MainPage SelectPriceForBuyingDeal(int price)
        {
            string StringPrice = price.ToString();
            StringPrice = StringPrice.Insert(1, " ");
            StringPrice = StringPrice.Insert(0, "$");
            _selectPriceField.Click();
            _selectPriceDropmenu.Click();

            Log.Info("Price for buying deal selected");

            return this;
        }

        public MainPage ConfirmBuyingDeal()
        {
            _confirmBuyingButton.Click();

            Log.Info("Buying deal confirmed");

            return this;
        }

        public MainPage CloseAllUnnecessaryWindows()
        {
            _understandButton.Click();
            _notNowButton.Click();

            Log.Info("All unnecessary windows closed");

            return this;
        }

        public MainPage SelectRealAccount()
        {
            _selectAccountTypeDropmenu.Click();
            _selectAccountTypeButton.Click();

            Log.Info("Account type was changed to Real");

            return this;
        }

        public MainPage CloseUnnecessaryWindow()
        {
            Thread.Sleep(3000);
            _closeRealAccountInformationButton.Click();

            Log.Info("Unnecessary window closed");

            return this;
        }

        public MainPage EndAllSessions()
        {
            Actions action = new Actions(Driver);
            action.MoveToElement(_submenuHover).Build().Perform();
            _activeSessionsButton.Click();
            _endAllSessionsButton.Click();

            Log.Info("EndingAllSessionsButton clicked");

            return this;
        }

        public MainPage ConfirmEndingAllSessions()
        {
            _confirmEndingAllSessionsButton.Click();

            Log.Info("Confirm ending all sessions");

            return this;
        }

        public MainPage AddCurrencyToFavourites()
        {
            _addToFavouritesButton.Click();

            Log.Info("Favourite currency added");

            return this;
        }

        public int GetBalance()
        {
            string textFormation;
            Thread.Sleep(1500);
            var balance = Driver.FindElement(_currentBalance);
            textFormation = balance.Text.Substring(1);
            textFormation = textFormation.Remove(2, 1);
            textFormation = textFormation.Remove(5, 3);
            return Int32.Parse(textFormation);
        }

        public MainPage SelectChangingBalance()
        {
            balanceBefore = GetBalance();
            Actions action = new Actions(Driver);
            action.MoveToElement(_submenuHover).Build().Perform();
            _changeDemoAccountBalanceButton.Click();

            Log.Info("ChangingBalance menu selected");

            return this;
        }

        public MainPage SelectValueOfChanging(int value)
        {
            _inputBalanceIncreaseField.SendKeys(value.ToString());

            Log.Info("Value of changing send");

            return this;
        }

        public MainPage ConfirmChangingBalance()
        {
            _confirmChangingBalanceButton.Click();
            _okChangingBalanceButton.Click();

            Log.Info("Value of changing send");

            return this;
        }

        public (int before, int after) GetBeforeAndAfterBalance()
        {
            Thread.Sleep(3000);
            return (balanceBefore, GetBalance());
        }

        public (IWebElement ordercurrency, IWebElement ordervalue) GetCurrencyAndValue()
        {
            var currency = Driver.FindElement(_currency);
            var value = Driver.FindElement(_value);

            return (currency, value);
        }

        public IWebElement GetAccountType()
        {
            return Driver.FindElement(_accountType);
        }

        public string GetChangedCurrency()
        {
            Thread.Sleep(1500);
            var currency = Driver.FindElement(_changedCurrency);
            return currency.Text.Insert(3, "/");
        }

        public string GetClosingSessionsText()
        {
            Thread.Sleep(1500);
            var text = Driver.FindElement(_allSessionsClosed);
            return text.Text;
        }

        public IWebElement GetFavouriteCurrency()
        {
            return Driver.FindElement(_favouritesCurrencies);
        }
    }
}
