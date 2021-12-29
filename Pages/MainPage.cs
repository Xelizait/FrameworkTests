using FrameworkTests.Utilites;
using OpenQA.Selenium;
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

        private readonly By _currency = By.XPath("//*[@id=\"region-active-investments\"]/div/div/div[5]/div/div[1]/div/div[1]/div[1]/div[1]/span[1]");
        private readonly By _value = By.XPath("//*[@id=\"region-active-investments\"]/div/div/div[5]/div/div[1]/div/div[1]/div[2]/div[2]/span[1]");
        private readonly By _accountType = By.CssSelector("span.ui-selectmenu-text.invest-account-select.real-account-select.selected");

        public ActiveDealsPage OpenActiveDealsPage()
        {
            _activeDealsButton.Click();

            Log.Info("Move to Active Deals page");

            return new ActiveDealsPage(Driver);
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

    }
}
