using OpenQA.Selenium;
using ZavrsniTest.Driver;

namespace ZavrsniTest.Page
{
    public class CheckoutPage
    {
        private IWebDriver driver = WebDrivers.Instance;
        public IWebElement Item => driver.FindElement(By.ClassName("summary_subtotal_label"));
        public IWebElement Total => driver.FindElement(By.ClassName("summary_total_label"));
        public IWebElement ButtonFinish => driver.FindElement(By.Id("finish"));
        public IWebElement OrderFinished => driver.FindElement(By.ClassName("complete-header"));
    }
}
