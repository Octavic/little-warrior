namespace Assets.Scripts.Utils
{
    using System;

    /// <summary>
    /// Defines a globally available random number generator
    /// </summary>
    public static class GlobalRandom
    {
        public static Random random = new Random();
        public static float NextFloat()
        {
            return (float)random.NextDouble();
        }
        public static int Next()
        {
            return random.Next();
        }
    }
}
