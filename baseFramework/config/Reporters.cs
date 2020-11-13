using AventStack.ExtentReports;
using System;
using System.Collections.Generic;
using System.Text;

namespace baseFramework.config {
    public static class Reporters {

        private static ExtentTest featureName1 { get; set; }
        private static ExtentTest scenario { get; set; }
        public static AventStack.ExtentReports.ExtentReports extent;
    
    }
}
