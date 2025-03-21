using System;
using OpenQA.Selenium;

namespace Multiple_WIndows_and_Frames
{
    public class WindowsPage
    {
        private readonly IWebDriver _driver;

        // Element Locators
        private By ClickHereLink => By.LinkText("Click Here");

        public WindowsPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Methods
        public void ClickClickHereLink()
        {
            _driver.FindElement(ClickHereLink).Click();
        }

        public void SwitchToNewWindow()
        {
            var windowHandles = _driver.WindowHandles;
            _driver.SwitchTo().Window(windowHandles[1]);
        }

        public string GetNewWindowText()
        {
            return _driver.FindElement(By.TagName("h3")).Text;
        }

        public void SwitchBackToOriginalWindow()
        {
            var windowHandles = _driver.WindowHandles;
            _driver.SwitchTo().Window(windowHandles[0]);
        }
    }
}
