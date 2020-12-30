using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;


namespace MSTestProject
{
    [TestClass]
    public class UnitTest1
    {
        IWebDriver driver = new ChromeDriver(@"D:\FreshersRampUp\MSTestFramework\");

        [TestInitialize]
        public void start()
        {
            driver.Navigate().GoToUrl("http://www.practiceselenium.com/welcome.html");
            driver.Manage().Window.Maximize();
            Thread.Sleep(5000);
        }

        [TestMethod]
        public void isImagePresent()
        {

            try
            {
                Assert.IsNotNull(driver.FindElement(By.XPath("//*[@id='wsb-element-00000000-0000-0000-0000-000450914885']/div/div/img")));
                Console.WriteLine("Image is prenent");
            }
            catch (AssertFailedException e)
            {
                Assert.Fail("Image not found");
            }
        }

        [TestMethod]
        public void isWelcomeActive() {
            try
            {
                Assert.IsNotNull(driver.FindElement(By.XPath("//*[@class='active']/a[contains(text(),'Welcome')]")));
                Console.WriteLine("Welcome is active");
            }
            catch (AssertFailedException e)
            {
                Assert.Fail("'Weclome' text is not in orange colour");
            }
        }
        [TestMethod]
        public void isPlaceOrderSuccessful() {
            Reader r = new Reader();

            IWebElement FlavouredTea = driver.FindElement(By.XPath("//*[@id='wsb-button-00000000-0000-0000-0000-000450914899']/span"));
            FlavouredTea.Click();

            try
            {
                Assert.IsNotNull(driver.FindElement(By.XPath("//*[@id='wsb-element-00000000-0000-0000-0000-000450914921']/div/h1[contains(text(),'Menu')]")));
                Console.WriteLine("Successfully navigated to 'Flavoured tea' page");
            }
            catch (AssertFailedException e)
            {
                Assert.Fail("Navigation failed");
            }

            string InputData = r.ReadTextFile(@"D:\FreshersRampUp\MSTestFramework\MSTestProject\MSTestProject\TestData\InputData.txt");
            string[] InputDataList = InputData.Split(", ");

            IWebElement CheckOut = driver.FindElement(By.XPath("//*[@id='wsb-button-00000000-0000-0000-0000-000451955160']/span"));
            CheckOut.Click();

            IWebElement Email = driver.FindElement(By.XPath("//*[@id='email']"));
            Email.SendKeys(InputDataList[0]);
            Thread.Sleep(2000);

            IWebElement Name = driver.FindElement(By.XPath("//*[@id='name']"));
            Name.SendKeys(InputDataList[1]);
            Thread.Sleep(2000);

            IWebElement Address = driver.FindElement(By.XPath("//*[@id='address']"));
            Address.SendKeys(InputDataList[2]);
            Thread.Sleep(2000);

            IWebElement DropDown = driver.FindElement(By.XPath("//*[@id='card_type']"));
            DropDown.Click();
            Thread.Sleep(4000);

            IWebElement Visa = driver.FindElement(By.XPath("//*[@id='card_type']/option[2]"));
            Visa.Click();
            Thread.Sleep(2000);

            IWebElement CardNumber = driver.FindElement(By.XPath("//*[@id='card_number']"));
            CardNumber.SendKeys(InputDataList[3]);
            Thread.Sleep(2000);

            IWebElement CardName = driver.FindElement(By.XPath("//*[@id='cardholder_name']"));
            CardName.SendKeys(InputDataList[4]);
            Thread.Sleep(2000);

            IWebElement VerificationCode = driver.FindElement(By.XPath("//*[@id='verification_code']"));
            VerificationCode.SendKeys(InputDataList[5]);
            Thread.Sleep(2000);

            IWebElement PlaceOrder = driver.FindElement(By.XPath("//*[@id='wsb-element-00000000-0000-0000-0000-000452010925']/div/div/form/div/button"));
            PlaceOrder.Click();
            Thread.Sleep(2000);

            Console.WriteLine("Order placed successfully");
        }

        [TestCleanup]
        public void end()
        {
            driver.Quit();
        }
    }
}

