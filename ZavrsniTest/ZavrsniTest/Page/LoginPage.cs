using OpenQA.Selenium;
using ZavrsniTest.Driver;

namespace ZavrsniTest.Page
{
    public class LoginPage
    {
        private IWebDriver driver = WebDrivers.Instance;

        public IWebElement UserName => driver.FindElement(By.Id("user-name"));
        public IWebElement Password => driver.FindElement(By.Id("password"));
        public IWebElement ButtonLogin => driver.FindElement(By.Id("login-button"));
        public IWebElement User2NotLogin => driver.FindElement(By.CssSelector(".error-message-container.error"));
        public IWebElement User4NotLogin => driver.FindElement(By.XPath("//*[@id=\"login_button_container\"]/div/form/div[3]/h3"));
        public IWebElement User5NotLogin => driver.FindElement(By.CssSelector("div.error-message-container"));
        public void Login(string name, string pass)
        {
            UserName.SendKeys(name);
            Password.SendKeys(pass);
            ButtonLogin.Submit();
        }
    }
}
