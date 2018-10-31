namespace Assets.Scripts.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine;
    using UnityEngine.UI;
    using Resource;

    /// <summary>
    /// UI representation of the Pizza
    /// </summary>
    public class PizzaUI : MonoBehaviour
    {
        /// <summary>
        /// A list of all slices
        /// </summary>
        private List<PizzaSliceUI> SliceUIs;

        /// <summary>
        /// Updates the pizza UI with the given pizza
        /// </summary>
        /// <param name="pizza">The new pizza</param>
        public void RenderPizza(Pizza pizza)
        {
            for (int i = 0; i < Settings.SliceCount; i++)
            {
                this.SliceUIs[i].RenderSlice(pizza.Slices[i]);
            }
        }

        /// <summary>
        /// Used for initialization
        /// </summary>
        protected void Start()
        {
            this.SliceUIs = this.GetComponentsInChildren<PizzaSliceUI>().OrderBy(ui => ui.gameObject.name).ToList();
            if (this.SliceUIs.Count != Settings.SliceCount)
            {
                Debug.LogError("Mismatching pizza slice UI count");
            }
        }
    }
}
