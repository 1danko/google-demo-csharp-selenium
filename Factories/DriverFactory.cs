using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Remote;
using QA.GoogleDemo.Support;

namespace QA.GoogleDemo.Factories
{
    public class DriverFactory
    {
        private readonly ScenarioContext _scenarioContext;

        public DriverFactory(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        public IWebDriver CreateDriver(string testName)
        {
            string dateTimeStamp = (DateTime.Now).ToString("MMddHHmmss");
            string videoName = testName + "_" + dateTimeStamp + ".mp4";
            string logName = testName + "_" + dateTimeStamp + ".log";
            _scenarioContext[string.Format("videoName{0}", testName)] = videoName;
            _scenarioContext[string.Format("logsName{0}", testName)] = logName;
            string browser = Hooks.config.browserName.ToLower();
            string env = Hooks.config.execEnv.ToLower();
            if (env == "local")
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
            else
                switch (browser.ToUpperInvariant())
                {
                    case "CHROME":
                        ChromeOptions options = new ChromeOptions();
                        options.BrowserVersion = "112.0";
                        options.AddUserProfilePreference("download.default_directory", "/home/selenium/Downloads/");
                        options.AddUserProfilePreference("download.prompt_for_download", false);
                        options.AddAdditionalOption("selenoid:options", new Dictionary<string, object>
                        {
                            ["name"] = testName,
                            ["sessionTimeout"] = "15m",
                            ["env"] = new List<string>() { "TZ=UTC" },
                            ["labels"] = new Dictionary<string, object>
                            {
                                ["manual"] = "false"
                            },
                            ["enableVideo"] = true,
                            ["enableVNC"] = true,
                            ["videoName"] = videoName,
                            ["enableLog"] = true,
                            ["logName"] = logName,
                        });
                        IWebDriver _rmdriver = new RemoteWebDriver(new Uri("http://13.93.116.50:4444/wd/hub"), options.ToCapabilities(), TimeSpan.FromMinutes(4));
                        return _rmdriver;
                    default:
                        throw new ArgumentException($"Browser not yet implemented: {browser}");
                }
        }
    }
}

