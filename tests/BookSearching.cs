using System;
using AventStack.ExtentReports;
using NUnit.Framework;
using SeleniumFramework.datatest;
using SeleniumFramework.pages;

namespace SeleniumFramework.tests
{
    [TestFixture]
    internal class BookSearching : BaseTest
    {
        public static void Main(string[] args)
        {
        }

        [Obsolete] private static readonly object[] DataSet = JsonReader.GetJsonDataSet();

        [Test]
        [TestCaseSource("DataSet")]
        [Parallelizable]
        [Obsolete]
        public void SearchBook(string key, string expected)
        {
            test = extent.CreateTest("Search the book");
            if (Pages.Home.openHome("https://www.amazon.com"))
                test.Log(Status.Pass, "Go to HomePage successful");
            else
                test.Log(Status.Fail, "Go to HomePage failed");

            if (Pages.Home.IsSelectValueSearch())
                test.Log(Status.Pass, "Select books successful");
            else
                test.Log(Status.Fail, "Select books failed");

            if (Pages.Home.SentKeyToSearchBox(key))
                test.Log(Status.Pass, "Enter book name successful");
            else
                test.Log(Status.Fail, "Enter book name failed");

            if (Pages.Home.ClickSearchButton())
                test.Log(Status.Pass, "Click button Search successful");
            else
                test.Log(Status.Fail, "Click button Search failed");
            
            if (Pages.SearchResult.VerifyBookTitle(expected))
                test.Log(Status.Pass, "Book's title matched");
            else
                test.Log(Status.Fail, "Book's title didn't matched");

            if (Pages.SearchResult.VerifyWebTitle("Amazon : " + key))
                test.Log(Status.Pass, "Web's title matched");
            else
                test.Log(Status.Fail, "Web's didn't matched");


        }
    }
}