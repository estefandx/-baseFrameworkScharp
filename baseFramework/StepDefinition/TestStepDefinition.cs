using baseFramework.tests;
using System;
using TechTalk.SpecFlow;

namespace baseFramework.StepDefinition
{
    [Binding]
    public class SpecFlowFeature1Steps : BaseStepDefinition {

        public SpecFlowFeature1Steps(ScenarioContext scenarioContext) : base(scenarioContext) {

        }
        [Given(@"the first number is (.*)")]
        public void GivenTheFirstNumberIs(int p0)
        {
            _webDriver.Navigate().GoToUrl("https://en.wikipedia.org");
        }
        
        [Given(@"the second number is (.*)")]
        public void GivenTheSecondNumberIs(int p0)
        {
            Console.WriteLine("ejecutar paso");
        }
        
        [When(@"the two numbers are added")]
        public void WhenTheTwoNumbersAreAdded()
        {
            Console.WriteLine("ejecutar paso");

        }
        
        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(int p0)
        {
            Console.WriteLine("ejecutar paso");

        }
    }
}
