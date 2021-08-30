using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using SeleniumAmwell.Pages;
using System;

namespace SeleniumAmwell
{
    [TestFixture]
    class PurchaseItem : BaseClass
    {
        [Test]
        public void BuyTshirts()
        {
            HomePage page = new HomePage(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            //Go to root URL and sign in
            page.IsReady();
            page.SignIn(login, password);

            //Purchasing steps
            page.WomenButton.Click();
            page.IsReady();
            page.TopsTile.Click();
            page.IsReady();
            page.FirstItem.Click();
            page.IsReady();
            page.QuantityTextBox.SendKeys("5");
            page.QuantityPlusButton.Click();
            page.MediumSizeDropdown.Click();
            page.AddToCartButton.Click();
            page.FacetIsVisible();
            page.ProceedToCheckoutFacetButton.Click();
            page.IsReady();

            //Completing order
            page.ProceedToCheckoutSummaryPageButton.Click();
            page.IsReady();
            page.ProceedToCheckoutOrderPageButton.Click();
            page.IsReady();
            page.TermsCheckbox.Click();
            page.ProceedToCheckoutShippingPageButton.Click();
            page.IsReady();
            page.PayByCheckButton.Click();
            page.OrderConfirmationButton.Click();
            page.IsReady();
            Assert.AreEqual(page.ConfirmationSuccesAllert.Text, "Your order on My Store is complete.");
        }
    }
}
