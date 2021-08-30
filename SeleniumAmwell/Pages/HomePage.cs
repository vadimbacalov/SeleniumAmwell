using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumAmwell.Pages
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public IWebElement Logo => driver.FindElement(By.XPath("//*[@id='header_logo']"));
        public IWebElement SignInButtonBreadcrumb => driver.FindElement(By.ClassName("login"));
        public IWebElement EmailAuthBox => driver.FindElement(By.Id("email"));
        public IWebElement PasswordAuthBox => driver.FindElement(By.Id("passwd"));
        public IWebElement SignInButton => driver.FindElement(By.Id("SubmitLogin"));
        public IWebElement WomenButton => driver.FindElement(By.XPath("//*[@id='block_top_menu']/ul/li[1]/a"));
        public IWebElement TopsTile => driver.FindElement(By.XPath("//*[@id='subcategories']/ul/li[1]/div[1]/a"));
        public IWebElement FirstItem => driver.FindElement(By.XPath("//*[@id='center_column']/ul/li[1]/div/div[2]/h5/a"));
        public IWebElement AddToCartButton => driver.FindElement(By.XPath("//*[@id='add_to_cart']/button"));
        public IWebElement QuantityTextBox => driver.FindElement(By.Id("quantity_wanted"));
        public IWebElement QuantityPlusButton => driver.FindElement(By.ClassName("icon-plus"));
        public IWebElement MediumSizeDropdown => driver.FindElement(By.Id("group_1")).FindElement(By.XPath(".//option[contains(text(),'M')]"));
        public IWebElement ProceedToCheckoutFacetButton => driver.FindElement(By.XPath("//*[@id='layer_cart']/div[1]/div[2]/div[4]/a"));
        public IWebElement ProceedToCheckoutSummaryPageButton => driver.FindElement(By.XPath("//*[@id='center_column']/p[2]/a[1]"));
        public IWebElement ProceedToCheckoutOrderPageButton => driver.FindElement(By.XPath("//*[@id='center_column']/form/p/button"));
        public IWebElement ProceedToCheckoutShippingPageButton => driver.FindElement(By.XPath("//*[@id='form']/p/button"));
        public IWebElement TermsCheckbox => driver.FindElement(By.Id("cgv"));
        public IWebElement PayByCheckButton => driver.FindElement(By.ClassName("cheque"));
        public IWebElement OrderConfirmationButton => driver.FindElement(By.XPath("//*[@id='cart_navigation']/button"));
        public IWebElement ConfirmationSuccesAllert => driver.FindElement(By.XPath("//*[@id='center_column']/p[1]"));


        public void IsReady()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='header_logo']")));
            Assert.IsTrue(Logo.Displayed);

        }

        public void FacetIsVisible()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[@id='layer_cart']/div[1]/div[2]/div[4]/a")));
            Assert.IsTrue(ProceedToCheckoutFacetButton.Displayed);
        }

        public void SignIn(string login, string password)
        {
            IsReady();
            SignInButtonBreadcrumb.Click();
            IsReady();
            EmailAuthBox.SendKeys(login);
            PasswordAuthBox.SendKeys(password);
            SignInButton.Click();
            IsReady();
            Logo.Click();
        }
    }
}
