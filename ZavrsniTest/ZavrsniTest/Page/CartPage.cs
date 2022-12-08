using OpenQA.Selenium;
using ZavrsniTest.Driver;

namespace ZavrsniTest.Page
{
    public class CartPage
    {
        private IWebDriver driver = WebDrivers.Instance;

        public IWebElement RemoveFirst => driver.FindElement(By.Id("remove-sauce-labs-onesie"));
        public IWebElement RemoveSecond => driver.FindElement(By.Id("remove-sauce-labs-bike-light"));
        public IWebElement ButtonBack => driver.FindElement(By.Id("continue-shopping"));
        public IWebElement ButtonCheckout => driver.FindElement(By.Id("checkout"));
    }
}
