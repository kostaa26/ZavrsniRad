using OpenQA.Selenium.DevTools.V106.WebAudio;
using ZavrsniTest.Driver;
using ZavrsniTest.Page;

namespace ZavrsniTest
{
    public class Tests
    {
        LoginPage loginPage;
        Buy3CheapestProd buy3CheapestProd;
        private string User4 = "Epic sadface: Username and password do not match any user in this service";
        [SetUp]
        public void Setup()
        {
            WebDrivers.Initialize();
            loginPage = new LoginPage();
            buy3CheapestProd = new Buy3CheapestProd();
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




    }
}