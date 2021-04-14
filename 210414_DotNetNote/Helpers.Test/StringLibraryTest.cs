using Microsoft.VisualStudio.TestTools.UnitTesting;
using Helpers;
using System;

// Helpers 에대해 단위테스트를 하는 테스트파일
namespace Helpers.Test
{
    [TestClass]
    public class StringLibraryTest
    {
        [TestMethod]
        public void CutStringTest()
        {
            string strCut = "Hello Wolrd, This is a test sentence";
            int intChar = 15;

            var expected = "Hello Wolrd,...";
            var actual = StringLibrary.CutString(strCut, intChar);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CutStringUnicodeTest()
        {
            string strCut = "안녕하세요 부경대학교 입니다.";
            int intChar = 9;

            var expected = "안녕하세요 ...";
            var actual = StringLibrary.CutString(strCut, intChar);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddTest()
        {

            var expected = 10;
            var actual = 5 + 5;
            Assert.AreEqual(expected, actual);
        }

    }
}
