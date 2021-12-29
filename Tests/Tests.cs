using FluentAssertions;
using FrameworkTests.Pages;
using FrameworkTests.Tests;
using NUnit.Framework;
using System;

namespace FrameworkTests
{
    [TestFixture]
    public class Test : SetUp
    {
        [Test]
        public void FastBuy()
        {
            var value = 5000;
            var currency = "EUR/USD";

            var fastBuy = new MainPage(driver)
                .StartCreatingBuyingDeal()
                .SelectPriceForBuyingDeal(value)
                .ConfirmBuyingDeal()
                .CloseAllUnnecessaryWindows()
                .GetCurrencyAndValue();

            var stringvalue = value.ToString();
            stringvalue = stringvalue.Insert(1, " ");
            stringvalue = stringvalue.Insert(0, "$");

            fastBuy.ordercurrency.Text.Should().Be(currency);
            fastBuy.ordervalue.Text.Should().Be(stringvalue);
        }

        [Test]
        public void CloseAllDeals()
        {
            var fastClose = new MainPage(driver)
                .OpenActiveDealsPage()
                .CloseAllDeals()
                .ConfirmClosingAllDeals()
                .BackToInvestigations()
                .GetInvestedMoney();
            
            fastClose.Text.Should().Be("$0.00");
        }

        [Test]
        public void CloseOneDeal()
        {
            var fastClose = new MainPage(driver)
                .OpenActiveDealsPage()
                .CloseOneDeal()
                .ConfirmClosingOneDeal()
                .GetInvestedMoney();

            fastClose.Text.Should().Be("$0.00");
        }

        [Test]
        public void ChangeAccountTypeToReal()
        {
            var fastChange = new MainPage(driver)
                .SelectRealAccount()
                .CloseUnnecessaryWindow()
                .GetAccountType();

            fastChange.Text.Should().Be("Libertex: ахры");
        }

        [Test]
        public void ChangeCurrency()
        {
            int currencyIndex = 3;
            var fastCurrencyChange = new MainPage(driver)
                .ChangeCurrency(currencyIndex)
                .GetChangedCurrency();

            fastCurrencyChange.Should().Be("USD/CAD");

            // currencyIndex from 2 to 8
            // 2 GBP/USD
            // 3 USD/CAD
            // 4 USD/JPY
            // 5 AUD/USD
            // 6 EUR/JPY
            // 7 USD/CHF
            // 8 NZD/USD
        }

    }
}