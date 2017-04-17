using NUnit.Framework;
using System;

namespace GmailUITest
{
    [TestFixture]
    public class TestClass
    {
        [Test]
        public void TestMethod()
        {
            GooglePageObject googleObj = new GooglePageObject();

            EmailPageObject accObjet = googleObj.TextAndPressButton("Gmail"); ;

            PassPageObject passObject = accObjet.FillEmail("dyakivrostik@gmail.com");

            GmailPageObject gmailObject = passObject.FillPassword("SomePassword4321");

            BoxMessagePageObject boxMessage = gmailObject.PressWriteButton();

            GmailMessagesPageObject messageCheckObject = boxMessage.FillMessageFormAndSend("dyakivrostik@gmail.com", "Some Message Subject", "Hello me, I'm just writing. Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry\'s standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum");

            messageCheckObject.FindUnreadMail("Some Message Subject");

            Console.WriteLine("Operations executed!");
        }
    }
}
