using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium
{
    [TestClass]
    public class SeleniumTest
    {
        ChromeDriver? driver = null;
        IWebElement messagesLink;
        [TestInitialize]
        public void Init()
        {
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://certicon-testing.azurewebsites.net/");
            messagesLink = driver.FindElement(By.LinkText("Messages"));
            messagesLink.Click();
        }
        [TestCleanup]
        public void Cleanup()
        {
            driver.Close();
        }
        [TestMethod]
        public void MessageSuccessfullySaved()
        {
            EnterTheName("Franta");
            EnterTheEmail("Franta@voprsalek.cz");
            EnterTheContent("Prvni zprava");
            ClickTheSubmitButton();
            IWebElement messageInfo = driver.FindElement(By.Id("messageNumber"));
            Assert.AreEqual("You have 1 messages", messageInfo.Text);
            IWebElement savedSuccessInfo = driver.FindElement(By.Id("success"));
            Assert.AreEqual("The message has been saved", savedSuccessInfo.Text);

        }
        IWebElement buttonCreate;
        private void ClickTheSubmitButton()
        {
            buttonCreate = driver.FindElement(By.Id("buttonCreate"));
            buttonCreate.Click();
        }

        IWebElement contentField;
        private void EnterTheContent(string content)
        {
            contentField = driver.FindElement(By.Id("Content"));
            contentField.SendKeys(content);
        }
        IWebElement emailField;
        private void EnterTheEmail(string email)
        {
            emailField = driver.FindElement(By.Id("Email"));
            emailField.SendKeys(email);
        }
        IWebElement nameField;
        private void EnterTheName(string name)
        {
            nameField = driver.FindElement(By.Id("Name"));
            nameField.SendKeys(name);
        }
        [TestMethod]
        public void ForgotToEnterName()
        {
            EnterTheEmail("karel@dopeklazajel.cz");
            EnterTheContent("Ahoj, tady Karel");
            ClickTheSubmitButton();
            IWebElement errorMessage = driver.FindElement(By.ClassName("validation-summary-errors"));
            Assert.AreEqual("Name is Required", errorMessage.Text);
        }
    }
}