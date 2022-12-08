using OpenQA.Selenium;
using ZavrsniTest.Driver;

namespace ZavrsniTest.Page
{
    public class FormPage
    {
        private IWebDriver driver = WebDrivers.Instance;

        public IWebElement FirstName => driver.FindElement(By.Id("first-name"));
        public IWebElement LastName => driver.FindElement(By.Id("last-name"));
        public IWebElement Zip => driver.FindElement(By.Id("postal-code"));
        public IWebElement SubmitContinue => driver.FindElement(By.Id("continue"));
    }
}
