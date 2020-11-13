using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using baseFramework.config;
using baseFramework.Constants;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace baseFramework.hooks {

    [Binding]
    class Hook {

       private static ExtentTest featureName;
       private static ExtentTest scenario;
        private static ExtentTest node;
        public static AventStack.ExtentReports.ExtentReports extent;
        private IWebDriver driver;


        [BeforeScenario]
        public void SetupTest(ScenarioContext context) {
            scenario = featureName.CreateNode<Scenario>(context.ScenarioInfo.Title);
            //IWebDriver driver;
            var factory = new WebDriverFactory();
            driver = factory.Create(BrowserType.Chrome);
            driver.Manage().Window.Maximize();
            context["WEB_DRIVER"] = driver;

        }

        [BeforeTestRun]
        public static void inicilizeReport() {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            ExtentHtmlReporter htmlReporter = new ExtentHtmlReporter(outPutDirectory);
            htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Configuration.Theme.Dark;
            extent = new AventStack.ExtentReports.ExtentReports();
            extent.AttachReporter(htmlReporter);

        }

        [BeforeFeature]
        public static void beforeFeature(FeatureContext featureContext) {
            featureName = extent.CreateTest<Feature>(featureContext.FeatureInfo.Title);
            Console.WriteLine("BeforeFeature");
        }

        [AfterScenario]
        public void CloseWebDriver(ScenarioContext context) {
            var driver = context["WEB_DRIVER"] as IWebDriver;
            driver.Quit();
            driver.Dispose();
            Console.WriteLine("ejecutar despues del scenario");
        }

        [AfterTestRun]
        public static void tearDownReport() {
            Console.WriteLine("se ejecuto este beforetestrun");
            extent.Flush();
        }

        [AfterStep]
        public  void InsertReportingSteps(ScenarioContext scenarioContext) {
            var stepType = ScenarioStepContext.Current.StepInfo.StepDefinitionType.ToString();
            if (scenarioContext.TestError == null) {
                if (stepType == "Given")
                   node =  scenario.CreateNode<Given>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "When")
                   node =  scenario.CreateNode<When>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "Then")
                   node =  scenario.CreateNode<Then>(ScenarioStepContext.Current.StepInfo.Text);
                else if (stepType == "And")
                   node =  scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text);
            } else if (scenarioContext.TestError != null) {
              
                if (stepType == "Given") {
                    failStepUtility(scenario,node, "Given ",scenarioContext);
                } else if (stepType == "When") {
                    failStepUtility(scenario, node, "When ", scenarioContext);
                } else if (stepType == "Then") {
                    failStepUtility(scenario, node, "Then ", scenarioContext);
                } else if (stepType == "And") {
                    failStepUtility(scenario, node, "And ", scenarioContext);
                }
            }

        }

        public static string Capture(IWebDriver driver, string screenShotNameImage) {
            ITakesScreenshot ts = (ITakesScreenshot)driver;
            Screenshot screenshot = ts.GetScreenshot();
            string screenShotName = screenShotNameImage + DateTime.Now.ToString("MM-dd-yyyy");
            string screenShotNamerep1 = screenShotName.Replace("/", "_");
            string screenShotNamerep2 = screenShotNamerep1.Replace(" ", "_");
            string screenShotNamerep3 = screenShotNamerep2.Replace(":", "_");
            string screenShotNamerep4 = screenShotNamerep3.Replace("-", "_");
            string finalpth = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string screenshotDir = finalpth + screenShotNamerep4 + ".png";
            Uri uri = new Uri(screenshotDir);
            string localpath = uri.LocalPath;
            screenshot.SaveAsFile(localpath);
            return localpath;
        }

        public void failStepUtility(ExtentTest scenario, ExtentTest node, string stepType, ScenarioContext scenarioContext) {
            string screenShotPath;
            DateTime now = DateTime.Now;
            node = scenario.CreateNode<And>(ScenarioStepContext.Current.StepInfo.Text)
                        .Fail(scenarioContext.TestError.Message + " -- " + scenarioContext.TestError.InnerException + " -- " + scenarioContext.TestError.Data + " -- " + scenarioContext.TestError.StackTrace);
            screenShotPath = Capture(driver, stepType + now);
            node.Log(Status.Fail, "Test fail", MediaEntityBuilder.CreateScreenCaptureFromPath(screenShotPath).Build());
        }
    }
}
