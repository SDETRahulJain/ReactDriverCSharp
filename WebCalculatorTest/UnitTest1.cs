using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ReactDriver.reactwebdriver;
using OpenQA.Selenium.Support;
using SeleniumExtras.PageObjects;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Xunit.Sdk;
using Xunit;

namespace WebCalculatorTest
{
    public class UnitTest1
    {
        WebDriver driver;
        ReactWebDriver reactWebDriver;

       
        public  UnitTest1()
        {

            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            reactWebDriver = new ReactWebDriver((IJavaScriptExecutor)driver, "#root");
            PageFactory.InitElements(driver, this);
            refreshWebPage();

        }
         
            public void refreshWebPage()
            {
                driver.Url = ("https://ahfarmer.github.io/calculator/");
                reactWebDriver.waitForReactToLoad();
                PageFactory.InitElements(driver, this);
            }

        [Fact]
        public void testFindByAnnotation()
        {
            Assert.Equal(driver.FindElements(ByReact.component("t")).Count, 22);

            /* Invalid react locator */
            Assert.Equal(driver.FindElements(ByReact.component("Calculator")).Count, 0);

            /* Full component name and props */
            Assert.Equal(driver.FindElements(ByReact.component("t").props("{ \"name\": \"5\" }"))[0].Text, "5");

            /* wildcard component name and props */
            Assert.Equal(driver.FindElements(ByReact.component("*").props("{ \"name\": \"3\" }"))[0].Text, "3");

            /* Using @Findy annotation */
           // Assert.Equal(equalToButton.getText(), "=");
        }
    }
}
