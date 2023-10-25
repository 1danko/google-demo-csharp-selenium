using BoDi;
using OpenQA.Selenium;
using Microsoft.Extensions.Configuration;
using QA.GoogleDemo.Factories;
using QA.GoogleDemo.Models;
using OpenQA.Selenium.Support.Extensions;
using Allure.Net.Commons;

namespace QA.GoogleDemo.Support
{
    [Binding]
    public class Hooks
    {
        private static AllureLifecycle allureLifecycle = AllureLifecycle.Instance;
        private readonly IObjectContainer _objectContainer;
        private IWebDriver _driver;
        public static ConfigSetting config;
        private static readonly string configsettingpath = Directory.GetParent(@"../../../").FullName + Path.DirectorySeparatorChar + "Resources/ExecEnv.json";

        public Hooks(IObjectContainer objectContainer)
        {
            _objectContainer = objectContainer;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            allureLifecycle.CleanupResultDirectory();
            config = new ConfigSetting();
            ConfigurationBuilder _builder = new ConfigurationBuilder();
            _builder.AddJsonFile(configsettingpath);
            IConfiguration configuration = _builder.Build();
            configuration.Bind(config); 
            EnvConfiguration.FormPropertiesFromJSON();
            Directory.CreateDirectory(Path.Combine("..", "..", "TestResults"));
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver = DriverFactory.CreateDriver();
            _objectContainer.RegisterInstanceAs(_driver);
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
        }

        [AfterScenario]
        [Obsolete]
        public void AfterScenario(ScenarioContext scenarioContext, ScenarioInfo info)
        {
            if (scenarioContext.TestError != null)
            {
                _driver.TakeScreenshot().SaveAsFile(Path.Combine("..", "..", "TestResults", $"{scenarioContext.ScenarioInfo.Title}.png"), ScreenshotImageFormat.Png);
            }
            _driver?.Dispose();
        }
    }
}
