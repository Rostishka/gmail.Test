using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace GmailUITest
{
    public class GooglePageObject
    {
        public GooglePageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.Name, Using = "q")]
        public IWebElement txtSearchField { get; set; }

        [FindsBy(How = How.LinkText, Using = "Gmail - Google")]
        public IWebElement txtGmail { get; set; }

        [FindsBy(How = How.Id, Using = "_fZl")]
        public IWebElement btnSearch { get; set; }

        public EmailPageObject WriteTextAndPressSearchButton(string searchText)
        {
            try
            {
                txtSearchField.EnterText(searchText);

                btnSearch.Click();

                Thread.Sleep(3000);

                txtGmail.Click();

                Thread.Sleep(5000);

                Assert.AreEqual("Gmail", PropertiesCollection.driver.Title);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Invalid window");
                PropertiesCollection.driver.Quit();
            }

            return new EmailPageObject();
        }
    }
}
