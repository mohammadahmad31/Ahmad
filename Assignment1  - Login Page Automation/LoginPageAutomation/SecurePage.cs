using OpenQA.Selenium;

public class SecurePage
{
    private readonly IWebDriver _driver;

    // Element Locators
    private By LogoutButton => By.CssSelector("a.button.secondary.radius");
    private By SuccessMessage => By.Id("flash");

    public SecurePage(IWebDriver driver)
    {
        _driver = driver;
    }

    // Methods
    public string GetSuccessMessage()
    {
        return _driver.FindElement(SuccessMessage).Text;
    }

    public void ClickLogout()
    {
        _driver.FindElement(LogoutButton).Click();
    }
}