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
        public Text CooldownText;

        public void RenderSlice(PizzaSlice targetSlice)
        {
            for (int i = 0; i < this.Toppings.Count; i++)
            {

                this.Toppings[i].gameObject.SetActive(targetSlice.Toppings.Contains((Topping)i));
            }

            this.PizzaBase.gameObject.SetActive(targetSlice.IsReady);
            this.CooldownText.gameObject.SetActive(!targetSlice.IsReady);

            if (targetSlice.BakeTimeLeft > 0)
            {
                this.CooldownText.gameObject.SetActive(true);
                this.CooldownText.text = targetSlice.BakeTimeLeft.ToString("0.0");
            }
        }
    }
}
