using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace GmailUITest
{
    public class GmailMessagesPageObject
    {
        public GmailMessagesPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        public void FindUnreadMail(string subject)
        {
            //Waiting for just sended email
            Thread.Sleep(20000);

            try
            {
                IWebElement el = PropertiesCollection.driver.FindElement(By.XPath("//span/b[text()='" + subject + "']"));
                Assert.IsTrue(el.Displayed);
            }
            catch (NoSuchElementException ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Web element doesn't excist!");
                PropertiesCollection.driver.Quit();
            }
        }
    }
}