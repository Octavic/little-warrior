namespace Assets.Scripts.Input
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine;

    public abstract class BaseController : MonoBehaviour
    {
        /// <summary>
        /// All of the nodes that's currently touched
        /// </summary>
        protected HashSet<int> TouchedNodes { get; set; }

        /// <summary>
        /// Adds a node to the inputs
        /// </summary>
        /// <param name="node">Target node</param>
        public void AddNode(int node)
        {
            if(this.TouchedNodes == null)
            {
                this.TouchedNodes = new HashSet<int>();
            }

            this.TouchedNodes.Add(node);
        }

        /// <summary>
        /// Finishes the current chain and executes it. Things like 
        ///     - lifting up finger in touch
        ///     - hitting space in keyboard
        ///     - returning joy stick to neutral with controller
        /// </summary>
        public void FinishTouch()
        {
            GameController.CurrentInstance.ExecuteInput(this.TouchedNodes);
            this.TouchedNodes = null;
        }

        /// <summary>
        /// Used for initialization
        /// </summary>
        protected virtual void Start()
        {
        }

        /// <summary>
        /// Called once per frame
        /// </summary>
        protected virtual void Update()
        {
        }
    }
}
