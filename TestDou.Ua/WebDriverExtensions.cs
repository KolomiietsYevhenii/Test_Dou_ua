using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace TestDou.Ua
{
    public static class WebDriverExtensions
    {
        public static void MaximizeWindow(this IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
        }

    }
}
