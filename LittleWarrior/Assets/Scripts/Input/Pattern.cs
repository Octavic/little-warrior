namespace Assets.Scripts.Input
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Describes all of the possible slices
    /// The letters maps to locations as following
    /// </summary>
    /// 1-----2------3
    /// |   A | E    |
    /// | B   |    F |
    /// 4-----5------6
    /// | C   |    G |
    /// |   D | H    |
    /// 7-----8------9
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
}
