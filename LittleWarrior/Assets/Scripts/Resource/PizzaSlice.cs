namespace Assets.Scripts.Resource
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Input;

    /// <summary>
    /// Pizza slice
    /// </summary>
    public class PizzaSlice
    {
        /// <summary>
        /// All toppings on the slice
        /// </summary>
        public HashSet<Topping> Toppings;

        /// <summary>
        /// How much time is left 
        /// </summary>
        public float BakeTimeLeft;

        public bool IsReady
        {
            get
            {
                return this.BakeTimeLeft <= 0;
            }
        }

        /// <summary>
        /// Creates a new instance of the <see cref="PizzaSlice"/> class 
        /// </summary>
        /// <param name="bakeTimeLeft">How much time is left when baking</param>
        public PizzaSlice(float bakeTimeLeft)
        {
            this.Toppings = new HashSet<Topping>();
            this.BakeTimeLeft = bakeTimeLeft;
        }

        /// <summary>
        /// Bakes the slice
        /// </summary>
        /// <param name="timePassed">How much time has passed</param>
        /// <returns>True if the slice was finished just now</returns>
        public bool Bake(float timePassed)
        {
            if(this.IsReady)
            {
                return false;
            }

            this.BakeTimeLeft = Math.Max(this.BakeTimeLeft - timePassed, 0);
            return this.IsReady;
        }
    }
}
