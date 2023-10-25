using OpenQA.Selenium;
using QA.GoogleDemo.PageObjects.GooglePages;

namespace QA.GoogleDemo.StepDefinitions.GoogleSteps
{
    [Binding]
    public class GoogleSearchteps
    {
        private readonly GoogleSearchPage _page;

        public GoogleSearchteps(IWebDriver driver)
        {
            _page = new GoogleSearchPage(driver);
        }

        [When(@"user search for ""(.*)""")]
        public void WhenUserSearchFor(string searchText)
        {
            _page.SearchFor(searchText);
        }

        [When(@"user select ""(.*)"" in the search results")]
        public void WhenUserSelectInTheSearchResults(string result)
        {
            _page.SelectResult(result);
        }
    }
}
