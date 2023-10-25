using OpenQA.Selenium;
using QA.GoogleDemo.PageObjects.GooglePages;

namespace QA.GoogleDemo.StepDefinitions.GoogleSteps
{
    [Binding]
    public class GoogleCookiesSubViewSteps
    {
        private readonly GoogleCookiesSubView _page;

        public GoogleCookiesSubViewSteps(IWebDriver driver)
        {
            _page = new GoogleCookiesSubView(driver);
        }

        [Given(@"user accept all cookies")]
        public void GivenUserAcceptAllCookies()
        {
            _page.AcceptAllCookies();
        }

        [Given(@"user select ""(.*)"" language")]
        public void GivenUserSelectLanguage(string language)
        {
            _page.SelectLanguageForGoogle(language);
        }
    }
}
