using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumFramework.util
{
    internal class Util
    {
        private static IWebDriver driver;

        public Util(IWebDriver d)
        {
            driver = d;
        }

        public static void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    if (driver == null)
                        driver = new FirefoxDriver();
                    break;

                case "Chrome":
                    if (driver == null)
                        driver = new ChromeDriver();
                    break;
            }
        }

        public static void CloseBrowser()
        {
            driver.Quit();
        }

        public static string GetTimestamp(DateTime value)
        {
            return value.ToString("HHmmss");
        }

        [Obsolete]
        public static IWebElement WaitForElementVisible(By locator)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
            return element;
        }

        public static bool ClickElement(IWebElement element)
        {
            var returnValue = false;
            try
            {
                element.Click();
                returnValue = true;
            }
            catch (NoSuchElementException exception)
            {
                Console.WriteLine("Element " + element + "not found on page " + driver.Title);
                returnValue = false;
            }
            catch (Exception exception)
            {
                Console.WriteLine("Unknown error " + exception.Message + " occurred on page " + driver.Title);
                returnValue = false;
            }

            return returnValue;
        }

        public static bool IsElementVisible(IWebElement element)
        {
            var returnValue = false;
            try
            {
                returnValue = element.Displayed;
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Element " + element + "not found on page " + driver.Title);
                returnValue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown error " + e.Message + " occurred on page " + driver.Title);
                returnValue = false;
            }

            return returnValue;
        }

        public static bool IsSelectValue(IWebElement element, string value)
        {
            var returnValue = false;
            try
            {
                var selection = new SelectElement(element);
                selection.SelectByText(value);
                returnValue = true;
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Element " + element + "not found on page " + driver.Title);
                returnValue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown error " + e.Message + " occurred on page " + driver.Title);
                returnValue = false;
            }

            return returnValue;
        }

        public static bool IsSentKey(IWebElement element, string value)
        {
            var returnValue = false;
            try
            {
                element.SendKeys(value);
                returnValue = true;
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Element " + element + "not found on page " + driver.Title);
                returnValue = false;
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown error " + e.Message + " occurred on page " + driver.Title);
                returnValue = false;
            }

            return returnValue;
        }

        public static bool GoToURL(string value)
        {
            var returnValue = false;
            try
            {
                driver.Url = value;
                driver.Manage().Window.Maximize();
                returnValue = true;
            }
            catch (NoSuchElementException e)
            {
                Console.WriteLine("Element " + "not found on page " + driver.Title);
            }
            catch (Exception e)
            {
                Console.WriteLine("Unknown error " + e.Message + " occurred on page " + driver.Title);
            }

            return returnValue;
        }

        public static String GetText(IWebElement element)
        {
            var text = "";
            try
            {
                text = element.Text.ToString();
            }
            catch (NoSuchElementException e)
            {
                return "Error: Element " + "not found on page " + driver.Title;
            }
            catch (Exception e)
            {
                return "Error: Unknown error " + e.Message + " occurred on page " + driver.Title;
            }

            return text;
        }

        public static String GetTitle()
        {
            var text = "";
            try
            {
                text = driver.Title.ToString();
            }
            catch (Exception e)
            {
                return "Error: Unknown error " + e.Message + " occurred on page " + driver.Title;
            }

            return text;
        }


        public static IWebDriver GetDriver()
        {
            if (driver == null)
                throw new NullReferenceException(
                    "The WebDriver browser instance was not initialized. You should first call the method InitBrowser.");
            return driver;
        }
    }
}