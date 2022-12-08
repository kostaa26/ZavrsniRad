using ZavrsniTest.Driver;
using ZavrsniTest.Page;

namespace ZavrsniTest
{
    public class Tests
    {
        LoginPage loginPage;
        HomePage homePage;
        CartPage cartPage;
        FormPage formPage;
        CheckoutPage checkoutPage;
        private string User4 = "Epic sadface: Username and password do not match any user in this service";
        [SetUp]
        public void Setup()
        {
            WebDrivers.Initialize();
            loginPage = new LoginPage();
            homePage = new HomePage();
            cartPage = new CartPage();
            formPage = new FormPage();
            checkoutPage = new CheckoutPage();
        }
        [TearDown]
        public void Close()
        {
            WebDrivers.CleanUp();
        }
        [Test]
        public void TC01_LoginUser1_ShouldLoginUser1()
        {
            loginPage.Login("standard_user", "secret_sauce");
            Assert.That("https://www.saucedemo.com/inventory.html", Is.EqualTo(WebDrivers.Instance.Url));
        }
        [Test]
        public void TC012_LoginUser2_ShouldNotLoginUser2()
        {
            loginPage.Login("locked_out_user", "secret_sauce");
            Assert.That("Epic sadface: Sorry, this user has been locked out.", Is.EqualTo(loginPage.User2NotLogin.Text));
        }
        [Test]
        public void TC013_LoginUser3_ShouldLoginUser3()
        {
            loginPage.Login("problem_user", "secret_sauce");
            Assert.That("https://www.saucedemo.com/inventory.html", Is.EqualTo(WebDrivers.Instance.Url));
        }
        [Test]
        public void TC014_LoginUser4_ShouldLoginUser4()
        {
            loginPage.Login("OpenToWork12345", "OpenToWork12345");
            Assert.That(User4, Is.EqualTo(loginPage.User4NotLogin.Text));
        }
        [Test]

        public void TC015_LoginUser5_ShouldNotLoginUser5()
        {
            loginPage.Login("", "");
            Assert.That("Epic sadface: Username is required", Is.EqualTo(loginPage.User5NotLogin.Text));
        }
        [Test]
        public void TC02_Buy3CheapestProduct_ShouldBuyed3CheapestProduct()
        {
            loginPage.Login("standard_user", "secret_sauce");
            homePage.SelectOption("Price (low to high)");
            homePage.Tshirt.Click();
            homePage.BikeLight.Click();
            homePage.BoltShirt.Click();
            Assert.That("3", Is.EqualTo(homePage.Cart.Text));
        }
        [Test]
        public void TC03_Add2ProdDeleteBothBackToHomePage_ShouldBuy2ProdRemoveFromCartBackToHomePage()
        {
            loginPage.Login("standard_user", "secret_sauce");
            homePage.SelectOption("Price (low to high)");
            homePage.Tshirt.Click();
            homePage.BikeLight.Click();
            homePage.Cart.Click();
            cartPage.RemoveFirst.Click();
            cartPage.RemoveSecond.Click();
            cartPage.ButtonBack.Click();
            Assert.That("", Is.EqualTo(homePage.Cart.Text));
        }
        [Test]
        public void TC04_CheckPriceInItemTotal_ShouldBeCheckedPriceInItemTotal()
        {
            loginPage.Login("standard_user", "secret_sauce");
            homePage.Tshirt.Click();
            homePage.Cart.Click();
            cartPage.ButtonCheckout.Click();
            formPage.FirstName.SendKeys("Kosta");
            formPage.LastName.SendKeys("Blagojevic");
            formPage.Zip.SendKeys("11030");
            formPage.SubmitContinue.Submit();
            Assert.That("Item total: $7.99", Is.EqualTo(checkoutPage.Item.Text));
        }
        [Test]
        public void TC05_CheckPriceInCartTotal_ShouldBeCheckedPriceInTotalCart()
        {
            loginPage.Login("standard_user", "secret_sauce");
            homePage.Tshirt.Click();
            homePage.Cart.Click();
            cartPage.ButtonCheckout.Click();
            formPage.FirstName.SendKeys("Kosta");
            formPage.LastName.SendKeys("Blagojevic");
            formPage.Zip.SendKeys("11030");
            formPage.SubmitContinue.Submit();
            Assert.That("Total: $8.63", Is.EqualTo(checkoutPage.Total.Text));
        }
        [Test]
        public void TC06_BuyOneProduct_ShouldBuyedOneProduct()
        {
            loginPage.Login("standard_user", "secret_sauce");
            homePage.Tshirt.Click();
            homePage.Cart.Click();
            cartPage.ButtonCheckout.Click();
            formPage.FirstName.SendKeys("Kosta");
            formPage.LastName.SendKeys("Blagojevic");
            formPage.Zip.SendKeys("11030");
            formPage.SubmitContinue.Submit();
            checkoutPage.ButtonFinish.Click();
            Assert.That("THANK YOU FOR YOUR ORDER", Is.EqualTo(checkoutPage.OrderFinished.Text));
        }
    }
}