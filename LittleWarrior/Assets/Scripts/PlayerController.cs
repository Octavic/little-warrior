namespace Assets.Scripts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine;
    using Resource;
    using Input;
    using UI;

    /// <summary>
    /// Defines the player controller
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        /// <summary>
        /// UI for the player pizza
        /// </summary>
        public PizzaUI PlayerPizzaUI;

        /// <summary>
        /// Pizza for the player
        /// </summary>
        public Pizza PlayerPizza;

        /// <summary>
        /// Executes the input
        /// </summary>
        /// <param name="touchedNodes"></param>
        public void ExecuteInput(HashSet<int> touchedNodes)
        {
            var consumedPatterns = PatternUtil.ParseInput(touchedNodes);
            var consumedSlices = this.PlayerPizza.ConsumeSlices(consumedPatterns);
        }

        public void ApplyTopping(int topping)
        {
            this.PlayerPizza.ApplyTopping((Topping)topping);
        }

        /// <summary>
        /// Used for initialization
        /// </summary>
        protected void Start()
        {
            this.PlayerPizza = new Pizza(new List<float>() { 1, 1, 1, 1, 1, 1, 1, 1 }, this.PlayerPizzaUI);
        }

        /// <summary>
        /// Called once per frame
        /// </summary>
        protected void Update()
        {
            this.PlayerPizza.Bake(Time.deltaTime);
        }
    }
}
