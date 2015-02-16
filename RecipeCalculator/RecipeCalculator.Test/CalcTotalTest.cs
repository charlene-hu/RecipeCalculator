using NUnit.Framework;
using RecipeCalculator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeCalculator.Test
{
    [TestFixture]
    public class CalcTotalTest
    {
        [Test]
        public void TestCalculate()
        {
            var items = new List<ItemDto>();
            items.Add(new ItemDto
            {
                IsOrganic = true,
                IsProduce = true,
                Price = 3.49m
                
            });
            items.Add(new ItemDto
            {
                IsOrganic = true,
                IsProduce = false,
                Price = 2.99m

            });
            items.Add(new ItemDto
            {
                IsOrganic = false,
                IsProduce = false,
                Price = 4.99m

            });
            var calc = new CalcTotal();
            var list = new List<decimal>();
            calc.Calculate(items, list);
            Assert.AreEqual(11.47, list[0], "");
        }

        [Test]
        public void TestCalc_ContainZero()
        {
            var items = new List<ItemDto>();
            items.Add(new ItemDto
            {
                IsOrganic = true,
                IsProduce = true,
                Price = 3.49m

            });
            items.Add(new ItemDto
            {
                IsOrganic = true,
                IsProduce = true,
                Price = 0

            });
            items.Add(new ItemDto
            {
                IsOrganic = false,
                IsProduce = true,
                Price = 4.99m

            });
            var calc = new CalcTotal();
            var list = new List<decimal>();
            calc.Calculate(items, list);
            Assert.AreEqual(8.48, list[0], "Should be Zero");
        }

        [Test]
        public void TestCalc_Return()
        {
            var items = new List<ItemDto>();
            items.Add(new ItemDto
            {
                IsOrganic = true,
                IsProduce = true,
                Price = -3.49m

            });
            items.Add(new ItemDto
            {
                IsOrganic = true,
                IsProduce = false,
                Price = -2.99m

            });
            items.Add(new ItemDto
            {
                IsOrganic = false,
                IsProduce = false,
                Price = -4.99m

            });
            var calc = new CalcTotal();
            var list = new List<decimal>();
            calc.Calculate(items, list);
            Assert.AreEqual(-11.47, list[0], "Negative for return");
        }

        [Test]
        public void TestCalc_NullFirstList()
        {
            var calc = new CalcTotal();
            var list = new List<decimal>();
            list.Add(10);
            calc.Calculate(null, list);
            Assert.True(true, "No exception when first list is null");
        }

        [Test]
        public void TestCalc_NullSecondList()
        {
            var items = new List<ItemDto>();
            items.Add(new ItemDto
            {
                IsOrganic = true,
                IsProduce = true,
                Price = -3.49m

            });
            items.Add(new ItemDto
            {
                IsOrganic = true,
                IsProduce = false,
                Price = -2.99m

            });
            items.Add(new ItemDto
            {
                IsOrganic = false,
                IsProduce = false,
                Price = -4.99m

            });
            var calc = new CalcTotal();
            List<decimal> list = null;
            calc.Calculate(items, list);
            Assert.True(true, "No exception when second list is null");
        }

        [Test]
        public void TestCalc_EmptyFirstList()
        {
            var calc = new CalcTotal();
            var list = new List<decimal>();
            list.Add(10);
            calc.Calculate(new List<ItemDto>(), list);
            Assert.True(true, "No exception when first list is empty");
        }

        [Test]
        public void TestCalc_EmptySecondList()
        {
            var items = new List<ItemDto>();
            items.Add(new ItemDto
            {
                IsOrganic = true,
                IsProduce = true,
                Price = -3.49m

            });
            items.Add(new ItemDto
            {
                IsOrganic = true,
                IsProduce = false,
                Price = -2.99m

            });
            items.Add(new ItemDto
            {
                IsOrganic = false,
                IsProduce = false,
                Price = -4.99m

            });
            var calc = new CalcTotal();
            List<decimal> list = new List<decimal>();
            calc.Calculate(items, list);
            Assert.True(true, "No exception when second list is empty");
        }
    }
}
