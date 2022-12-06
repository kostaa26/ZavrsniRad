using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZavrsniTest.Driver;

namespace ZavrsniTest.Page
{
    public class Buy3CheapestProd
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








    }
}
