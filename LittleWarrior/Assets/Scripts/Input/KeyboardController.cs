namespace Assets.Scripts.Input
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine;

    /// <summary>
    /// Defines a keyboard controller
    /// </summary>
    public class KeyboardController : BaseController
    {
        /// <summary>
        /// A map of keyboard keycode to the node that it'll hit
        /// </summary>
        private Dictionary<KeyCode, int> keycodeToNodeMap = new Dictionary<KeyCode, int>()
        {
            { KeyCode.Q, 1 },
            { KeyCode.W, 2 },
            { KeyCode.E, 3 },
            { KeyCode.A, 4 },
            { KeyCode.S, 5 },
            { KeyCode.D, 6 },
            { KeyCode.Z, 7 },
            { KeyCode.X, 8 },
            { KeyCode.C, 9 },
        };

        protected override void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.FinishTouch();
            }

            foreach (var key in this.keycodeToNodeMap.Keys)
            {
                if (Input.GetKeyDown(key))
                {
                    this.AddNode(this.keycodeToNodeMap[key]);
                }
            }

            base.Update();
        }
    }
}
