using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumFramework.util;

namespace SeleniumFramework.pages
{
    internal class SearchResultPage
    {
        //########### Element Definition #############

        [FindsBy(How = How.XPath, Using = "//*[@class='a-size-mini a-spacing-none a-color-base s-line-clamp-2']")]
        [CacheLookup]
        public IWebElement BookTitle { get; set; }

        //######### Function Definition #################

        public bool VerifyBookTitle(String title)
        {
            if (Util.GetText(BookTitle).Contains("Error: "))
                return false;
            if (Util.GetText(BookTitle).Equals(title))
            {
                return true;
            }
            else
                return false;
        }

        public bool VerifyWebTitle(String title)
        {
            if (Util.GetTitle().Contains(title))
            {
                return true;
            }
            else
                return false;
        }


    }
}
