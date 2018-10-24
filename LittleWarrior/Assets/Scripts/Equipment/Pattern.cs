namespace Assets.Scripts.Equipment
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Describes all of the possible slices
    /// The letters maps to locations as following
    /// --------------
    /// |   A | E    |
    /// | B   |    F |
    /// --------------
    /// | C   |    G |
    /// |   E | H    |
    /// --------------
    /// </summary>
    public enum Pattern
    {
        A,
        B,
        C,
        D,
        E,
        F,
        G,
        H,
    }

    /// <summary>
    /// Extends the Pattern enum
    /// </summary>
    public static class PatternExtensions
    {
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
    }
}
