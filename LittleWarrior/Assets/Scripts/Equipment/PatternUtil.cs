namespace Assets.Scripts.Equipment
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Extends the Pattern enum
    /// </summary>
    /// 1-----2------3
    /// |   A | E    |
    /// | B   |    F |
    /// 4-----5------6
    /// | C   |    G |
    /// |   D | H    |
    /// 7-----8------9
    public static class PatternUtil
    {
        /// <summary>
        /// A map of pattern => required edge nodes (aside from 5 which is always required)
        /// </summary>
        private static Dictionary<Pattern, List<int>> Requirements = new Dictionary<Pattern, List<int>>()
        {
            {Pattern.A, new List<int>() { 2, 1 } },
            {Pattern.B, new List<int>() { 1, 4 } },
            {Pattern.C, new List<int>() { 4, 7 } },
            {Pattern.D, new List<int>() { 7, 8 } },

            {Pattern.E, new List<int>() { 2, 3 } },
            {Pattern.F, new List<int>() { 3, 6 } },
            {Pattern.G, new List<int>() { 6, 9 } },
            {Pattern.H, new List<int>() { 9, 8 } },
        };

        /// <summary>
        /// Gets the opposite "slice"
        /// </summary>
        /// <param name="p">Pattern base class</param>
        /// <returns>The opposite slice</returns>
        public static Pattern GetOpposite(this Pattern p)
        {
            var asInt = (int)p;
            var result = (asInt + 4) % 8;
            return (Pattern)result;
        }

        /// <summary>
        /// Parses touched input nodes into fulfilled patterns
        /// </summary>
        /// <param name="touchedNodes">List of touched nodes</param>
        /// <returns>Fulfilled patterns</returns>
        public static HashSet<Pattern> ParseInput(HashSet<int> touchedNodes)
        {
            if (!touchedNodes.Contains(5))
            {
                return new HashSet<Pattern>();
            }

            return new HashSet<Pattern>(Requirements.Keys.Where(pattern => Requirements[pattern].All(touchedNodes.Contains)));
        }
    }
}
