﻿using System;
using System.Linq;
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

        public static IWebElement WaitUntilElementToBeClickable(this IWebDriver driver, By findBy, TimeSpan timeout)
        {
            WebDriverWait wait = new WebDriverWait(driver, timeout);
            IWebElement element = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(findBy));
            return element;
        }

        public static void Wait(this IWebDriver driver)
        {
           // driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3000));
        }

        public static void IsElementPresent(this IWebDriver driver, By by)
        {
            // try
            {
                driver.FindElement(by);
                // return true;
            }
            //  catch (NoSuchElementException)
            //  {
            //      return false;
            //   }
        }

        public static void TakeScreenshot(this IWebDriver driver, string filename)
        {
            ITakesScreenshot screenShotDriver = (ITakesScreenshot)driver;
            Screenshot screenshot = screenShotDriver.GetScreenshot();
            screenshot.SaveAsFile(AppDomain.CurrentDomain.BaseDirectory + $"{filename}.png" + $"{filename}.png", ScreenshotImageFormat.Png);
        }
    }
}