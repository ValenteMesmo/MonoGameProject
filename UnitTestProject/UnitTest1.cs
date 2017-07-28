using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using MonoGameProject;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        private TileMerger sut = new TileMerger();

        [TestMethod]
        public void TestMethod2()
        {
            var actual = sut.getMergedTiles("111").First();
            Assert.AreEqual('1', actual.Type);
            Assert.AreEqual(1, actual.X);
            Assert.AreEqual(1, actual.Y);
            Assert.AreEqual(3, actual.W);
            Assert.AreEqual(1, actual.H);
        }

        [TestMethod]
        public void TestMethod3()
        {
            var actual = sut.getMergedTiles("0001111111111111").ToArray();
            Assert.AreEqual('0', actual[0].Type);
            Assert.AreEqual(1, actual[0].X);
            Assert.AreEqual(1, actual[0].Y);
            Assert.AreEqual(3, actual[0].W);
            Assert.AreEqual(1, actual[0].H);

            Assert.AreEqual('1', actual[1].Type);
            Assert.AreEqual(4, actual[1].X);
            Assert.AreEqual(1, actual[1].Y);
            Assert.AreEqual(13, actual[1].W);
            Assert.AreEqual(1, actual[1].H);
        }

        [TestMethod]
        public void TestMethod4()
        {
            var actual = sut.getMergedTiles(
                  "10"
                , "10").ToArray();

            Assert.AreEqual('1', actual[0].Type);
            Assert.AreEqual(1, actual[0].X);
            Assert.AreEqual(1, actual[0].Y);
            Assert.AreEqual(1, actual[0].W);
            Assert.AreEqual(2, actual[0].H);
        }

        [TestMethod]
        public void TestMethod5()
        {
            var actual = sut.getMergedTiles(
                  "110"
                , "110").ToArray();

            Assert.AreEqual('1', actual[0].Type);
            Assert.AreEqual(1, actual[0].X);
            Assert.AreEqual(1, actual[0].Y);
            Assert.AreEqual(2, actual[0].W);
            Assert.AreEqual(2, actual[0].H);
        }

        [TestMethod]
        public void TestMethod6()
        {
            var actual = sut.getMergedTiles(
                  "100"
                , "111").ToArray();

            Assert.AreEqual('1', actual[0].Type);
            Assert.AreEqual(1, actual[0].X);
            Assert.AreEqual(1, actual[0].Y);
            Assert.AreEqual(1, actual[0].W);
            Assert.AreEqual(1, actual[0].H);

            Assert.AreEqual('0', actual[1].Type);
            Assert.AreEqual(2, actual[1].X);
            Assert.AreEqual(1, actual[1].Y);
            Assert.AreEqual(2, actual[1].W);
            Assert.AreEqual(1, actual[1].H);

            Assert.AreEqual('1', actual[2].Type);
            Assert.AreEqual(1, actual[2].X);
            Assert.AreEqual(2, actual[2].Y);
            Assert.AreEqual(3, actual[2].W);
            Assert.AreEqual(1, actual[2].H);
        }


        [TestMethod]
        public void TestMethod7()
        {
            var actual = sut.getMergedTiles(
                  "111"
                , "101").ToArray();

            Assert.AreEqual(4, actual.Length);

            Assert.AreEqual('1', actual[0].Type);
            Assert.AreEqual(1, actual[0].X);
            Assert.AreEqual(1, actual[0].Y);
            Assert.AreEqual(3, actual[0].W);
            Assert.AreEqual(1, actual[0].H);

            Assert.AreEqual('1', actual[1].Type);
            Assert.AreEqual(1, actual[1].X);
            Assert.AreEqual(2, actual[1].Y);
            Assert.AreEqual(1, actual[1].W);
            Assert.AreEqual(1, actual[1].H);

            Assert.AreEqual('0', actual[2].Type);
            Assert.AreEqual(2, actual[2].X);
            Assert.AreEqual(2, actual[2].Y);
            Assert.AreEqual(1, actual[2].W);
            Assert.AreEqual(1, actual[2].H);
        }

        [TestMethod]
        public void TestMethod8()
        {
            var actual = sut.getMergedTiles(
                  "000"
                , "111"
                , "111").ToArray();

            Assert.AreEqual(2, actual.Length);
        }

        [TestMethod]
        public void TestMethod9()
        {
            var actual = sut.getMergedTiles(
                  "111"
                , "110"
                , "110").ToArray();

            Assert.AreEqual(3, actual.Length);
        }

    }
}