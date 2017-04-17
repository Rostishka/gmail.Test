using NUnit.Framework;
using System;
using System.Security.Cryptography.X509Certificates;

namespace GmailUITest
{
    [SetUpFixture]
    public class GmailUITestSetUp
    {
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            PropertiesCollection.driver.Navigate().GoToUrl("https://www.google.com");
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            PropertiesCollection.driver.Quit();
        }
    }
}