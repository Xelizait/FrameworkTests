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

        private readonly By _currency = By.XPath("//*[@id=\"region-active-investments\"]/div/div/div[5]/div/div[1]/div/div[1]/div[1]/div[1]/span[1]");
        private readonly By _value = By.XPath("//*[@id=\"region-active-investments\"]/div/div/div[5]/div/div[1]/div/div[1]/div[2]/div[2]/span[1]");

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

        public (IWebElement ordercurrency, IWebElement ordervalue) GetCurrencyAndValue()
        {
            var currency = Driver.FindElement(_currency);
            var value = Driver.FindElement(_value);

            return (currency, value);
        }

    }
}
