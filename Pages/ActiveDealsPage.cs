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
    public class ActiveDealsPage : PageFactoryBase
    {
        public ActiveDealsPage(IWebDriver driver) : base(driver)
        {

        }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"region-multiple-close-main\"]/div/div")]
        private IWebElement _closeAllDealsDropmenu;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"region-multiple-close-main\"]/div/ul/li[3]")]
        private IWebElement _closeAllDealsButton;

        [FindsBy(How = How.XPath, Using = "//*[@id=\"modal\"]/div/div[2]/span[2]")]
        private IWebElement _confirmClosingAllDealsButton;

        [FindsBy(How = How.CssSelector, Using = "span.a-btn.a-btn-blue.go-trade")]
        private IWebElement _backToInvestigationsButton;

        private readonly By _investedMoney = By.XPath("//*[@id=\"region-main\"]/div/div[6]/div[2]");

        public ActiveDealsPage CloseAllDeals()
        {
            _closeAllDealsDropmenu.Click();
            _closeAllDealsButton.Click();

            Log.Info("Clicked on ClosingAllDeals button");

            return this;
        }

        public ActiveDealsPage ConfirmClosingAllDeals()
        {
            _confirmClosingAllDealsButton.Click();

            Log.Info("Closing all deals was confirmed");

            return this;
        }

        public ActiveDealsPage BackToInvestigations()
        {
            _backToInvestigationsButton.Click();

            Log.Info("Closing all deals was confirmed");

            return this;
        }

        public IWebElement GetInvestedMoney()
        {
            Thread.Sleep(5000);
            return Driver.FindElement(_investedMoney);
        }
    }
}