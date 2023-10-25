using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace QA.GoogleDemo.PageObjects
{
    public class PageObject
    {
        private readonly IWebDriver _driver;

        public PageObject(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ScrollToElement(IWebElement element) {
            Actions actions = new Actions(_driver);
            actions.MoveToElement(element);
            actions.Perform();
        }

        public void Navigate(string url)
        {
            _driver.Navigate().GoToUrl(url);
        }

        public bool IsElementDisplayed(IWebElement element)
        {
            return element.Displayed;
        }

        public bool IsElementDisplayed(By locator, double secs)
        {
            WaitForDisplayed(locator, secs);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(secs);
            return _driver.FindElement(locator).Displayed;
        }

        public bool IsElementEnabled(By locator, double secs)
        {
            return _driver.FindElement(locator).Enabled;
        }

        public void WaitForDisplayed(By locator, double seconds)
        {
            WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
            w.Until(ExpectedConditions.ElementExists(locator));
        }

        public void WaitForInvisibilityOfElement(By locator, double seconds)
        {
            WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
            w.Until(ExpectedConditions.InvisibilityOfElementLocated(locator));
        }

        public void WaitForClickable(By locator, double seconds)
        {
            WebDriverWait w = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
            w.Until(ExpectedConditions.ElementToBeClickable(locator));
        }
    }
}
