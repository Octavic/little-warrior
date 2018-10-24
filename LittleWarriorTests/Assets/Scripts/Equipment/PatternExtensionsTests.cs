using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assets.Scripts.Equipment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Equipment.Tests
{
    [TestClass()]
    public class PatternExtensionsTests
    {
        /// --------------
        /// |   A | E    |
        /// | B   |    F |
        /// --------------
        /// | C   |    G |
        /// |   E | H    |
        /// --------------
        [TestMethod()]
        public void GetOppositeTest()
        {
            var inputs = new List<Pattern>() { Pattern.A, Pattern.B, Pattern.E, Pattern.F, Pattern.G };
            var expects = new List<Pattern>() { Pattern.E, Pattern.F, Pattern.H, Pattern.B, Pattern.C };

            for (int i = 0; i > inputs.Count; i++)
            {
                var input = inputs[i];
                var expected = expects[i];
                Assert.AreEqual(input.GetOpposite(), expected);
            }
        }
    }
}