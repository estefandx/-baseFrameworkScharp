using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace baseFramework.tests {
    [Binding]
    class BuyDressStepsDefinition : BaseStepDefinition {

        public BuyDressStepsDefinition(ScenarioContext scenarioContext):base(scenarioContext) {
           
        }

        [Given(@"that Maria selects the following dresses")]

        public void GivenThatMariaSelectsTheFollowingDresses(Table table) {
            _webDriver.Navigate().GoToUrl("https://en.wikipedia.org");
            Assert.Fail("este test debe fallar");

        }

            [When(@"She goes to the cart")]
        public void WhenSheGoesToTheCart() {
            Console.WriteLine("se ejecutoi el step");
        }

        [When(@"creates a profile to buy")]
        public void WhenCreatesAProfileToBuy() {
            Console.WriteLine("se ejecutoi el step");
        }

        [Then(@"she should see the message Your order on My Store is complete\. as confirmation message")]
        public void ThenSheShouldSeeTheMessageYourOrderOnMyStoreIsComplete_AsConfirmationMessage() {
            Console.WriteLine("se ejecutoi el step");
            //Assert.Fail();
        }

    }
}
