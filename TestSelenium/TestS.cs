using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestSelenium
{
    [TestClass]
    public class TestS

    {


        [TestMethod]
        public void TestMethod1()
        {

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://localhost:56145/Index.aspx");
            driver.Manage().Window.Maximize();


    }
    }
}

