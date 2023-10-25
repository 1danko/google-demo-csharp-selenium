using OpenQA.Selenium;
using QA.GoogleDemo.Support;


namespace QA.GoogleDemo.StepDefinitions
{
    [Binding]
    public class CommonSteps
    {
        private readonly IWebDriver _driver;

        public CommonSteps(IWebDriver driver)
        {
            _driver = driver;
        }

        [When(@"user switch to ""(.*)"" tab in browser")]
        public void WhenUserSwitchToTabInBrowser(int tab)
        {
            _driver.SwitchTo().Window(_driver.WindowHandles[tab - 1]);
        }

        [When(@"user close current tab in browser")]
        public void WhenUserCloseCurrentTabInBrowser()
        {
            _driver.Close();
        }

        [Given(@"user navigates to ""(.*)"" url")]
        public void GivenUserNavigatesToUrl(string url)
        {
            url = EnvConfiguration.serviceUrlMap.ContainsKey(url) ? EnvConfiguration.serviceUrlMap[url] : url;
            _driver.Navigate().GoToUrl(url);
        }

        [Then(@"title of the page is ""(.*)""")]
        public void ThenTitleOfThePageIs(string title)
        {
            string pageTitle = _driver.Title;
            Assert.AreEqual(title, pageTitle, $"title pf the page is {title}");
        }
    }
}
