using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace GmailUITest
{
    public class PassPageObject
    {
        public PassPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.Name, Using = "Passwd")]
        public IWebElement txtPassword { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#signIn")]
        public IWebElement btnSingIn { get; set; }

        public GmailPageObject FillPasswordForm(string password)
        {
            try
            {
                txtPassword.EnterText(password);

                btnSingIn.ClickOn();

                Thread.Sleep(10000);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                Console.WriteLine("Cant fill the form");
                PropertiesCollection.driver.Quit();
            }

            return  new GmailPageObject();
        }
    }
}
