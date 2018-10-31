namespace Assets.Scripts.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine;
    using UnityEngine.UI;
    using Resource;

    public class PizzaSliceUI : MonoBehaviour
    {
        public Image PizzaBase;
        public List<Image> Toppings;
        public PizzaSliceCooldown CooldownText;

        /// <summary>
        /// Renders the target slice
        /// </summary>
        /// <param name="targetSlice">Target slice</param>
        public void RenderSlice(PizzaSlice targetSlice)
        {
            for (int i = 0; i < this.Toppings.Count; i++)
            {
                this.Toppings[i].gameObject.SetActive(targetSlice.Toppings.Contains((Topping)i));
            }

            this.PizzaBase.gameObject.SetActive(targetSlice.IsReady);

            if(!targetSlice.IsReady)
            {
                this.CooldownText.WatchSlice(targetSlice);
            }
        }
    }
}
