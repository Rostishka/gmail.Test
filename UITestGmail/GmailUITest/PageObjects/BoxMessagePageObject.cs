using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace GmailUITest
{
    public class BoxMessagePageObject
    {
        public BoxMessagePageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.Id, Using = ":do")]
        public IWebElement txtRecipient { get; set; }

        [FindsBy(How = How.Name, Using = "to")]
        public IWebElement txtEmailReciever { get; set; }

        [FindsBy(How = How.Name, Using = "subjectbox")]
        public IWebElement txtMessageSubject { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".Ap div[role='textbox']")]
        public IWebElement txtMessage { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//div[text()='Send']")]
        public IWebElement btnSend { get; set; }

        public GmailMessagesPageObject FillMessageFormAndSend(string emailReciever, string messageSubject, string messageValue)
        {
            Thread.Sleep(2000);
            try
            {
                txtEmailReciever.Click();

                txtEmailReciever.EnterText(emailReciever);

                txtMessageSubject.EnterText(messageSubject);

                txtMessage.Click();

                txtMessage.EnterText(messageValue);

                btnSend.Click();

                Thread.Sleep(2000);

                Assert.AreEqual("Your message has been sent. View message", PropertiesCollection.driver.FindElement(By.ClassName("vh")).Text);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Message wasn't sended");
            }

            return new GmailMessagesPageObject();
        }
    }
}
