
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace baseFramework.tests {

    [Binding]
    public class BaseStepDefinition {

        protected readonly IWebDriver _webDriver;

        public BaseStepDefinition(ScenarioContext scenarioContext) {
            _webDriver = scenarioContext["WEB_DRIVER"] as IWebDriver;
        }

    }
}
