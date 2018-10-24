using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assets.Scripts.Input;
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
        /// 1-----2------3
        /// |   A | E    |
        /// | B   |    F |
        /// 4-----5------6
        /// | C   |    G |
        /// |   D | H    |
        /// 7-----8------9
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

        [TestMethod()]
        public void ParseInputTest_NoCenter()
        {
            Assert.AreEqual(PatternUtil.ParseInput(new HashSet<int>() { 1, 2, 3, 4 }).Count, 0);
        }

        /// 1-----2------3
        /// |   A | E    |
        /// | B   |    F |
        /// 4-----5------6
        /// | C   |    G |
        /// |   D | H    |
        /// 7-----8------9
        [TestMethod()]
        public void ParseInputTest_SinglePiece()
        {
            var inputs = new List<HashSet<int>>()
            {
                new HashSet<int>() { 1, 2, 5 },
                new HashSet<int>() { 2, 3, 5 },
                new HashSet<int>() { 7, 8, 5 },
                new HashSet<int>() { 9, 6, 5 },
            };
            var expects = new List<Pattern>()
            {
                Pattern.A,
                Pattern.E,
                Pattern.D,
                Pattern.G
            };

            for (int i = 0; i < inputs.Count; i++)
            {
                var input = inputs[i];
                var expect = expects[i];

                var result = PatternUtil.ParseInput(input);
                Assert.AreEqual(result.Count, 1);
                Assert.IsTrue(result.Contains(expect));
            }
        }

        /// 1-----2------3
        /// |   A | E    |
        /// | B   |    F |
        /// 4-----5------6
        /// | C   |    G |
        /// |   D | H    |
        /// 7-----8------9
        [TestMethod()]
        public void ParseInputTest_InvalidCombinations()
        {
            var inputs = new List<HashSet<int>>()
            {
                new HashSet<int>() { 1, 3, 5 },
                new HashSet<int>() { 2, 4, 5 },
                new HashSet<int>() { 6, 8, 5 },
                new HashSet<int>() { 1, 3, 9, 5 },
            };

            for (int i = 0; i < inputs.Count; i++)
            {
                var input = inputs[i];
                var result = PatternUtil.ParseInput(input);
                Assert.AreEqual(result.Count, 0);
            }
        }

        /// 1-----2------3
        /// |   A | E    |
        /// | B   |    F |
        /// 4-----5------6
        /// | C   |    G |
        /// |   D | H    |
        /// 7-----8------9
        [TestMethod()]
        public void ParseInputTest_MultiplePieces()
        {
            var inputs = new List<HashSet<int>>()
            {
                new HashSet<int>() { 1, 2, 3, 5 },
                new HashSet<int>() { 1, 2, 4, 5 },
                new HashSet<int>() { 1, 2, 5, 8, 9 },
                new HashSet<int>() { 1, 2, 6, 7, 5 },
            };
            var expects = new List<List<Pattern>>()
            {
                new List<Pattern> { Pattern.A, Pattern.E },
                new List<Pattern> { Pattern.A, Pattern.B },
                new List<Pattern> { Pattern.A, Pattern.H },
                new List<Pattern> { Pattern.A },
            };

            for (int i = 0; i < inputs.Count; i++)
            {
                var input = inputs[i];
                var expect = expects[i];

                var result = PatternUtil.ParseInput(input);
                Assert.AreEqual(result.Count, expect.Count);
                Assert.IsTrue(expect.All(item => result.Contains(item)));
            }
        }
    }
}