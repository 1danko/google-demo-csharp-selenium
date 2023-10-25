using OpenQA.Selenium;

namespace QA.GoogleDemo.PageObjects.GooglePages
{
    public class GoogleSearchPage : PageObject
    {
        private readonly By searchAreaLocator = By.XPath("//textarea[@type='search']");
        private readonly By searchResultsLocator = By.CssSelector("h3[class*='DKV0Md']");

        private readonly IWebDriver _driver;

        public GoogleSearchPage(IWebDriver driver) : base(driver)
        {
            _driver = driver;
        }

        public void SearchFor(string searchText)
        {
            SearchArea.Clear();
            SearchArea.SendKeys(searchText);
            SearchArea.Submit();
        }

        public void SelectResult(string expResult)
        {
            SearchResults
                .First(element => element.Text.Contains(expResult))
                .Click();
        }

        private IWebElement SearchArea => _driver.FindElement(searchAreaLocator);
        private IList<IWebElement> SearchResults => _driver.FindElements(searchResultsLocator);
    }
}
