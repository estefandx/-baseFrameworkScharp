using baseFramework.Constants;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace baseFramework.config {
    class WebDriverFactory {

        public IWebDriver Create(BrowserType browserType) {

            switch (browserType) {
                case BrowserType.Chrome:
                    return GetChromeDriver();
                default:
                    throw new ArgumentOutOfRangeException("no such browser exists");

            }
        }

        private IWebDriver GetChromeDriver() {
            var outPutDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            return new ChromeDriver(outPutDirectory);
        }


    }
}
