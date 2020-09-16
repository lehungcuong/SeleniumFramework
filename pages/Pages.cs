using System;
using OpenQA.Selenium.Support.PageObjects;
using SeleniumFramework.util;

namespace SeleniumFramework.pages
{
    internal class Pages
    {
        [Obsolete] public static Home Home => GetPage<Home>();

        [Obsolete] public static SearchResultPage SearchResult => GetPage<SearchResultPage>();

        [Obsolete]
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(Util.GetDriver(), page);
            return page;
        }
    }
}