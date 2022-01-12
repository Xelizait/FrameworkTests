using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameworkTests.Driver;
using NUnit.Framework;

namespace FrameworkTests.Utilites
{
    public static class ScreenshotHelper
    {
        public static void TakeScreenshot()
        {
            string screenshotName = $"{DateTime.Now.ToString("dd-MM-yy HH.mm")} - {TestContext.CurrentContext.Test.MethodName}.png";
            string screenshotPath = "X:\\BSTU\\3 year\\5 семестр\\QA EPAM\\FrameworkTests\\Utilites\\Screenshots";

            if (!Directory.Exists(screenshotPath))
            {
                Directory.CreateDirectory(screenshotPath);
            }

           ((ITakesScreenshot)Driver.GetDriver())
              .GetScreenshot()
              .SaveAsFile(screenshotPath + screenshotName, ScreenshotImageFormat.Png);
        }
    }
}
