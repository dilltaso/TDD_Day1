using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Day1Homework_TDD;
using System.Collections.Generic;
using FluentAssertions;

namespace Day1Homework_TDD_Test
{
    [TestClass]
    public class Day1Homework_TDD_Test
    {
        List<IProductInfo> products = null;

        [TestInitialize]
        public void TestInit()
        {
            products = new List<IProductInfo>()
            {
                new ProductInfo(1, 1, 11, 21),
                new ProductInfo(2, 2, 12, 22),
                new ProductInfo(3, 3, 13, 23),
                new ProductInfo(4, 4, 14, 24),
                new ProductInfo(5, 5, 15, 25),
                new ProductInfo(6, 6, 16, 26),
                new ProductInfo(7, 7, 17, 27),
                new ProductInfo(8, 8, 18, 28),
                new ProductInfo(9, 9, 19, 29),
                new ProductInfo(10, 10, 20, 30),
                new ProductInfo(10, 11, 21, 31)
            };

        }

        [TestCleanup]
        public void TestCleanUp()
        {
            products.Clear();
        }

        [TestMethod]
        public void 三個成員為一組_每組取Cost總和_結果為4組分別為_6_15_24_21()
        {
            //arrange
            var expected = new List<int> { 6, 15, 24, 21 };            

            //act
            var actual = GroupSum.getSumByGroup(products, 3, "cost");

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 四個成員為一組_每組取Revenue總和_結果為3組分別為_50_66_60()
        {
            //arrange
            var expected = new List<int> { 50, 66, 60 };

            //act
            var actual = GroupSum.getSumByGroup(products, 4, "revenue");

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 數字超過集合成員數量為一組_每組取Cost總和_結果視為1組並為_66()
        {
            //arrange
            var expected = new List<int> { 66 };

            //act
            var actual = GroupSum.getSumByGroup(products, 100, "cost");

            //assert
            CollectionAssert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void 負數值的成員為一組_將拋出例外_ArgumentOutOfRangeException()
        {
            //arrange
            var expected = new List<int> { };

            //act
            Action act = () => GroupSum.getSumByGroup(products, -1, "cost");

            //assert
            act.ShouldThrow<ArgumentOutOfRangeException>();   
        }
    }
}
