namespace Assets.Scripts.UI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Resource;
    using UnityEngine;
    using UnityEngine.UI;

    /// <summary>
    /// A class that displays the pizza's bake time
    /// </summary>
    public class PizzaSliceCooldown : MonoBehaviour
    {
        /// <summary>
        /// The slice that this cooldown is watching
        /// </summary>
        PizzaSlice watchingSlice;

        /// <summary>
        /// The text component
        /// </summary>
        Text textComponent;

        /// <summary>
        /// Watches the slice
        /// </summary>
        /// <param name="slice">Target slice</param>
        public void WatchSlice(PizzaSlice slice)
        {
            this.watchingSlice = slice;
            this.gameObject.SetActive(true);
        }

        /// <summary>
        /// Used for initialization
        /// </summary>
        protected void Start()
        {
            this.textComponent = this.GetComponent<Text>();
        }

        /// <summary>
        /// Called once per frame
        /// </summary>
        protected void Update()
        {
            if (this.watchingSlice != null)
            {
                var timeLeft = this.watchingSlice.BakeTimeLeft;
                if (timeLeft <= 0)
                {
                    this.watchingSlice = null;
                    this.gameObject.SetActive(false);
                    return;
                }

                this.textComponent.text = this.watchingSlice.BakeTimeLeft.ToString("0.0");
            }
        }
    }
}
