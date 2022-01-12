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
        [Test, Order(2)]
        public void FastBuy()
        {
            var value = 5000;
            var currency = "EUR/USD";

            var fastBuy = new MainPage(FrameworkTests.Driver.Driver.GetDriver())
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

        [Test, Order(1)]
        public void CloseAllDeals()
        {
            var fastClose = new MainPage(FrameworkTests.Driver.Driver.GetDriver())
                .OpenActiveDealsPage()
                .CloseAllDeals()
                .ConfirmClosingAllDeals()
                .BackToInvestigations()
                .GetInvestedMoney();
            
            fastClose.Text.Should().Be("$0.00");
        }

        [Test, Order(3)]
        public void CloseOneDeal()
        {
            var fastClose = new MainPage(FrameworkTests.Driver.Driver.GetDriver())
                .OpenActiveDealsPage()
                .CloseOneDeal()
                .ConfirmClosingOneDeal()
                .GetInvestedMoney();

            fastClose.Text.Should().Be("$0.00");
        }

        [Test, Order(7)]
        public void ChangeAccountTypeToReal()
        {
            var fastChange = new MainPage(FrameworkTests.Driver.Driver.GetDriver())
                .SelectRealAccount()
                .CloseUnnecessaryWindow()
                .GetAccountType();

            fastChange.Text.Should().Be("Libertex: Реал");
        }

        [Test, Order(4)]
        public void CloseAllSessions()
        {
            var fastEnding = new MainPage(FrameworkTests.Driver.Driver.GetDriver())
                .EndAllSessions()
                .ConfirmEndingAllSessions()
                .GetClosingSessionsText();

            fastEnding.Should().Be("Сеансы завершены");
        }

        [Test, Order(5)]
        public void CreateFavouriteCurrency()
        {
            var favouriteCurrency = new MainPage(FrameworkTests.Driver.Driver.GetDriver())
                .AddCurrencyToFavourites()
                .GetFavouriteCurrency();

            favouriteCurrency.Should().NotBeNull();
        }

    }
}