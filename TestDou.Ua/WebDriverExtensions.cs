using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestDou.Ua
{
    public static class WebDriverExtensions
    {
        public static void MaximizeWindow(this IWebDriver driver)
        {
            driver.Manage().Window.Maximize();
        }

        public static void SwitchToLastWindow(this IWebDriver driver)
        {
            driver.SwitchTo().Window(driver.WindowHandles.Last());
        }

        public static void WaitUntilElementDisappear(this IWebDriver driver, By findBy, TimeSpan timeout)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeout);
            bool element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(findBy));
        }

        public static void WaitUntilElementToBeClickable(this IWebDriver driver, By findBy, TimeSpan timeout)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeout);
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(findBy));
        }

    }
    }
