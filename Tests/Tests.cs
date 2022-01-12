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
        public void ChangePhoneNumber()
        {
            var changedPhone = new MainPage(FrameworkTests.Driver.Driver.GetDriver())
                .OpenSettingsPage()
                .ChangePhoneNumber()
                .ConfirmChangingPhoneNumber()
                .GetPhoneChangedText();

            changedPhone.Should().Be("SMS код");
        }

        [Test, Order(6)]
        public void CreateNewDemoAccount()
        {
            var newAccount = new MainPage(FrameworkTests.Driver.Driver.GetDriver())
                .OpenSettingsPage()
                .StartCreatingDemoAccount()
                .CreatingDemoAccount()
                .GetCreatedAccount();

            newAccount.Should().NotBeNull();
        }

        [Test, Order(7)]
        public void CloseDemoAccount()
        {
            var deleteAccount = new MainPage(FrameworkTests.Driver.Driver.GetDriver())
                .OpenSettingsPage()
                .DeleteCreatedDemoAccount()
                .ConfirmDeletingDemoAccount()
                .GetClosingAccountText();

            deleteAccount.Should().Be("Ваш аккаунт успешно закрыт");
        }

        [Test, Order(8)]
        public void ChangeBalance()
        {
            int value = 10000;

            var changeBalance = new MainPage(FrameworkTests.Driver.Driver.GetDriver())
                .SelectChangingBalance()
                .SelectValueOfChanging(value)
                .ConfirmChangingBalance()
                .GetBeforeAndAfterBalance();

            changeBalance.after.Should().Be(changeBalance.before + value);
        }

        [Test, Order(9)]
        public void CreateFavouriteCurrency()
        {
            var favouriteCurrency = new MainPage(FrameworkTests.Driver.Driver.GetDriver())
                .AddCurrencyToFavourites()
                .GetFavouriteCurrency();

            favouriteCurrency.Should().NotBeNull();
        }

        [Test, Order(10)]
        public void ChangeAccountTypeToReal()
        {
            var fastChange = new MainPage(FrameworkTests.Driver.Driver.GetDriver())
                .SelectRealAccount()
                .CloseUnnecessaryWindow()
                .GetAccountType();

            fastChange.Text.Should().Be("Libertex: Реал");
        }

    }
}