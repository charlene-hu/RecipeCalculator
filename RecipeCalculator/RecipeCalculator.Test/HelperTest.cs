using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeCalculator.Test
{
    [TestFixture]
    public class HelperTest
    {
        [Test]
        public void TestRoundToSevenCent_RoundUnitOnly()
        {
            decimal test = 10.01m;
            decimal result = Helper.RoundToSevenCent(test);
            Assert.AreEqual(10.07, result, "Should be 7 in cent place");
        }

        [Test]
        public void TestRoundToSevenCent_RoundTenAndUnit()
        {
            decimal test = 10.09m;
            decimal result = Helper.RoundToSevenCent(test);
            Assert.AreEqual(10.14, result, "Should round up both decimal places");
        }

        [Test]
        public void TestRoundToSevenCent_NoRounding()
        {
            decimal test = 10.07m;
            decimal result = Helper.RoundToSevenCent(test);
            Assert.AreEqual(10.07, result, "Should not round up");
        }

        [Test]
        public void TestRoundToSevenCent_Zero()
        {
            decimal test = 0;
            decimal result = Helper.RoundToSevenCent(test);
            Assert.AreEqual(0, result, "Should be zero");
        }

        [Test]
        public void TestRoundToSevenCent_Negative()
        {
            decimal test = -10.65m;
            decimal result = Helper.RoundToSevenCent(test);
            Assert.AreEqual(-10.63m, result, "Negative");
        }
    }
}
