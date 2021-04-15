﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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

        [Ignore]   // []로 쓰는 친구들을 어트리뷰트라고 부르며, 실행하면서 처리를 바꿔주는 동적인 속성중 하나.(이그노어는 이거안하고 넘긴다는뜻)
        [TestMethod]
        public void AddTest()
        {

            var expected = 10;
            var actual = 5 + 5;
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void IsPhotoTest()
        {
            var imagePath = @"D:\GitRepository\StudyAspNet21\210414_DotNetNote\210414_DotNetNote\images\dnn\key_login.gif";  // 이미지 파일경로
            bool result = BoardLibrary.IsPhoto(imagePath);
            Assert.IsTrue(result, "file extension must be png, jpg, gif");
        }

        [TestMethod]
        public void IsNotPhotoTest()
        {
            var imagePath = @"D:\GitRepository\StudyAspNet21\210414_DotNetNote\210414_DotNetNote\images\dnn\key_login.gif";  // 이미지 파일경로
            bool result = BoardLibrary.IsPhoto(imagePath);
            Assert.IsFalse(result, "file extension must be png, jpg, gif");
        }

    }
}
