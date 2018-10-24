﻿namespace Assets.Scripts.Resource
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Input;
    using UnityEngine;

    /// <summary>
    /// Defines the whole pizza
    /// </summary>
    public class Pizza
    {
        /// <summary>
        /// Number of slices in a pizza
        /// </summary>
        public const int SliceCount = 8;

        /// <summary>
        /// The current slices
        /// </summary>
        public List<PizzaSlice> Slices;

        /// <summary>
        /// How long it takes for each slice to bake
        /// </summary>
        private List<float> BakeTimes;

        /// <summary>
        /// Creates a new instance of the <see cref="Pizza"/> class
        /// </summary>
        /// <param name="bakeTimes"></param>
        public Pizza(List<float> bakeTimes)
        {
            if(bakeTimes.Count != SliceCount)
            {
                Debug.LogError("Mismatching bake time count with pizza slices");
                throw new ArgumentException();
            }

            this.BakeTimes = bakeTimes;
            this.Slices = new List<PizzaSlice>();
            for(int i = 0; i < SliceCount; i++)
            {
                this.Slices.Add(new PizzaSlice(bakeTimes[i]));
            }
        }

        /// <summary>
        /// Applies topping to the whole pizza
        /// </summary>
        /// <param name="topping">Target topping to be added</param>
        public void ApplyTopping(Topping topping)
        {
            foreach(var slice in this.Slices)
            {
                slice.Toppings.Add(topping);
            }
        }

        /// <summary>
        /// Bakes the pizza
        /// </summary>
        /// <param name="timePassed">How much time to bake for</param>
        public void Bake(float timePassed)
        {
            foreach(var slice in this.Slices)
            {
                slice.Bake(timePassed);
            }
        }

        /// <summary>
        /// Consumes the slices in the given pattern
        /// </summary>
        /// <param name="patterns">Target patterns</param>
        /// <returns>Consumed slices</returns>
        public List<PizzaSlice> ConsumeSlices(HashSet<Pattern> patterns)
        {
            var result = new List<PizzaSlice>();
            foreach (var pattern in patterns)
            {
                var index = (int)pattern;
                var targetSlice = this.Slices[index];
                if(targetSlice.IsReady)
                {
                    result.Add(targetSlice);
                    this.Slices[index] = new PizzaSlice(this.BakeTimes[index]);
                }
            }

            return result;
        }
    }
}