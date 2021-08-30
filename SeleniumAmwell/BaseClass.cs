using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace SeleniumAmwell
{
    [TestFixture]
    public class BaseClass
    {

        public IWebDriver driver;
        private static IConfigurationRoot config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json").Build();
        public string url = config.GetSection("Settings").GetSection("URL").Value;
        public string login = config.GetSection("Settings").GetSection("login").Value;
        public string password = config.GetSection("Settings").GetSection("password").Value;

        [TestFixtureSetUp]
        public void TestSetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
            driver.Navigate().GoToUrl(url); 
        }

        [TestFixtureTearDown]
        public void TestTearDown()
        {
            driver.Quit();
        }
    }
}
