using OpenQA.Selenium;

namespace QA.GoogleDemo.PageObjects.GooglePages
{
    public class GoogleCookiesSubView : PageObject
    {
        private readonly By acceptCookiesButtonLocator = By.Id("L2AGLb");
        private readonly By openLanguageMenuLocator = By.Id("vc3jof");
        private readonly string languagesMenuItemsLocator = "//div[@role='menu']//li[contains(., '{0}')]";

        private readonly IWebDriver _driver;

        public GoogleCookiesSubView(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void SelectLanguageForGoogle(string language)
        {
            WaitForDisplayed(openLanguageMenuLocator, 5);
            openLanguageMenuButton.Click();
            var languageItem = _driver.FindElement(By.XPath(string.Format(languagesMenuItemsLocator, language)));
            ScrollToElement(languageItem);
            languageItem.Click();
        }

        public void AcceptAllCookies()
        {
            WaitForDisplayed(acceptCookiesButtonLocator, 5);
            ScrollToElement(AcceptCookiesButton);
            AcceptCookiesButton.Click();
        }

        private IWebElement AcceptCookiesButton => _driver.FindElement(acceptCookiesButtonLocator);
        private IWebElement openLanguageMenuButton => _driver.FindElement(openLanguageMenuLocator);

    }
}
