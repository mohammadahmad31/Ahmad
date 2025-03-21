using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

public class LoginPage
{
    private readonly IWebDriver _driver;
    private readonly WebDriverWait _wait;

    // Element Locators
    private By UsernameField => By.Id("username");
    private By PasswordField => By.Id("password");
    private By LoginButton => By.CssSelector("button[type='submit']");
    private By FlashMessage => By.Id("flash");

    public LoginPage(IWebDriver driver)
    {
        _driver = driver;
        _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
    }

    // Methods
    public void EnterUsername(string username)
    {
        _driver.FindElement(UsernameField).SendKeys(username);
    }

    public void EnterPassword(string password)
    {
        _driver.FindElement(PasswordField).SendKeys(password);
    }

    public void ClickLogin()
    {
        _driver.FindElement(LoginButton).Click();
    }

    public string GetFlashMessage()
    {
        return _driver.FindElement(FlashMessage).Text;
    }

    public SecurePage LoginWithValidCredentials(string username, string password)
    {
        EnterUsername(username);
        EnterPassword(password);
        ClickLogin();
        return new SecurePage(_driver);
    }
}