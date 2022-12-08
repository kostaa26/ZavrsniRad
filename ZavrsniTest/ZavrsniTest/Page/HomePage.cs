using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using ZavrsniTest.Driver;

namespace ZavrsniTest.Page
{
    public class HomePage
    {
        private IWebDriver driver = WebDrivers.Instance;
        public void SelectOption(string text)
        {
            SelectElement SelectByPriceLowToHigh = new SelectElement(driver.FindElement(By.ClassName("product_sort_container")));

            SelectByPriceLowToHigh.SelectByText(text);
        }
        public IWebElement Tshirt => driver.FindElement(By.Id("add-to-cart-sauce-labs-onesie"));
        public IWebElement BikeLight => driver.FindElement(By.Id("add-to-cart-sauce-labs-bike-light"));
        public IWebElement BoltShirt => driver.FindElement(By.Id("add-to-cart-sauce-labs-bolt-t-shirt"));
        public IWebElement Cart => driver.FindElement(By.ClassName("shopping_cart_link"));
    }
}
