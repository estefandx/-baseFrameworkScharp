using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace baseFramework.Pages {
    class BaseApplicationPage {

        public BaseApplicationPage(IWebDriver driver) {
            Driver = driver;
        }

        protected IWebDriver Driver { get; set; }

    }
}
