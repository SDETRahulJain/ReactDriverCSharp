using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ReactDriver.reactwebdriver;
using OpenQA.Selenium.Support;
using SeleniumExtras.PageObjects;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using Xunit.Sdk;
using Xunit;

namespace ReactDriver
{
    public class WebDriverCalculatorAppTest
    {

        WebDriver driver;
        ReactWebDriver reactWebDriver;
       // ByReactComponent.FindBy findBy = new ByReactComponent.FindBy();
        //ByReactComponent.FindBy
        //    (

        //    name = "t",
        //    prop = "{\"name\": \"=\"}"
        //    )

        //    public WebElement equalToButton;

        //@ByReactComponent.FindBy
        //    (
        //        name = "t",
        //        prop = "{ \"name\": \"invalid\" }"
        //    )

        public WebElement invalidElement;

        public void setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            reactWebDriver = new ReactWebDriver((IJavaScriptExecutor)driver, "#root");
            PageFactory.InitElements(driver, this);
        }

        [Fact]
        public void refreshWebPage()
        {
            driver.Url = ("https://ahfarmer.github.io/calculator/");
            reactWebDriver.waitForReactToLoad();
            PageFactory.InitElements(driver, this);
        }

    }
}