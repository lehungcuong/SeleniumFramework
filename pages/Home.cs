using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumFramework.util;

namespace SeleniumFramework.pages
{
    internal class Home
    {
        //########### Element Definition #############

        [FindsBy(How = How.XPath, Using = "//*[@id='searchDropdownBox']")]
        [CacheLookup]
        public IWebElement SearchDropdownBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@id='twotabsearchtextbox']")]
        [CacheLookup]
        public IWebElement SearchBox { get; set; }

        [FindsBy(How = How.XPath, Using = "//input[@value='Go']")]
        [CacheLookup]
        public IWebElement BtnSearch { get; set; }

        //######### Function Definition #################
        public bool isHomePageLoaded()
        {
            return Util.IsElementVisible(SearchDropdownBox);
        }

        public bool IsSelectValueSearch()
        {
            return Util.IsSelectValue(SearchDropdownBox, "Books");
        }

        public bool openHome(string url)
        {
            return Util.GoToURL(url);
        }

        public bool SentKeyToSearchBox(string target)
        {
            return Util.IsSentKey(SearchBox, target);
        }

        public bool ClickSearchButton()
        {
            return Util.ClickElement(BtnSearch);
        }
    }
}