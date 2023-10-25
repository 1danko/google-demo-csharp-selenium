using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using QA.GoogleDemo.Support;

namespace QA.GoogleDemo.Factories
{
    public class DriverFactory
    {
        public static IWebDriver CreateDriver()
        {
            string browser = Hooks.config.browserName.ToLower();
            string env = Hooks.config.execEnv.ToLower();
            if (env == "local")
            {
                switch (browser.ToUpperInvariant())
                {
                    case "CHROME":
                        ChromeOptions options = new ChromeOptions();
                        options.AddUserProfilePreference("intl.accept_languages", "en");
                        return new ChromeDriver(options);
                    case "FIREFOX":
                        return new FirefoxDriver();
                    case "IE":
                        return new InternetExplorerDriver();
                    default:
                        throw new ArgumentException($"Browser not yet implemented: {browser}");
                }
            }
            else
            {
                throw new ArgumentException($"Execution env not yet implemented: {env}");
            }
        }
    }