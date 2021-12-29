using FluentAssertions;
using FrameworkTests.Pages;
using FrameworkTests.Tests;
using NUnit.Framework;

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
    }
}