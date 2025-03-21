using Multiple_WIndows_and_Frames;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MultipleWindowsFrames
{
    [TestFixture]
    public class WindowsTests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
        }

        [TearDown]
        public void Teardown()
        {
            _driver.Dispose();
            _driver.Quit();
        }

        [Test]
        public void TestMultipleWindows()
        {
            _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/windows");
            var windowsPage = new WindowsPage(_driver);
            windowsPage.ClickClickHereLink();
            windowsPage.SwitchToNewWindow();
            //Assert.AreEqual("New Window", windowsPage.GetNewWindowText());
            Assert.That(windowsPage.GetNewWindowText(), Is.EqualTo("New Window"));
            windowsPage.SwitchBackToOriginalWindow();
        }
    }
}