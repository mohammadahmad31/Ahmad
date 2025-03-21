using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

[TestFixture]
public class LoginTests
{
    private IWebDriver _driver;

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/login");
    }

    [TearDown]
    public void Teardown()
    {
        _driver.Dispose();
        _driver.Quit();
    }

    [Test]
    [TestCase("tomsmith", "SuperSecretPassword!", true)]
    [TestCase("wronguser", "wrongpass", false)]
    [TestCase("", "", false)]
    public void TestLogin(string username, string password, bool expectedSuccess)
    {
        var loginPage = new LoginPage(_driver);
        loginPage.EnterUsername(username);
        loginPage.EnterPassword(password);
        loginPage.ClickLogin();

        if (expectedSuccess)
        {
            var securePage = new SecurePage(_driver);
            Assert.IsTrue(securePage.GetSuccessMessage().Contains("You logged into a secure area!"));
            securePage.ClickLogout();
        }
        else
        {
            Assert.IsTrue(loginPage.GetFlashMessage().Contains("Your username is invalid!") ||
                           loginPage.GetFlashMessage().Contains("Your password is invalid!"));
        }
    }
}