using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace GmailUITest
{
    public class EmailPageObject
    {
        public EmailPageObject()
        {
            PageFactory.InitElements(PropertiesCollection.driver, this);
        }

        [FindsBy(How = How.Name, Using = "Email")]
        public IWebElement txtEmail { get; set; }

        [FindsBy(How = How.Name, Using = "signIn")]
        public IWebElement btnNext { get; set; }


        public PassPageObject FillEmailForm(string userEmail)
        {
            try
            {
                txtEmail.EnterText(userEmail);

                btnNext.ClickOn();

                Thread.Sleep(3000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                Console.WriteLine("Can't click the Next button");
                PropertiesCollection.driver.Quit();
            }
         
            return new PassPageObject();
        }
    }
}
