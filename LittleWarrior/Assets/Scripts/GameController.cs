namespace Assets.Scripts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine;
    using Input;

    /// <summary>
    /// Controls the overall flow of the game
    /// </summary>
    public class GameController : MonoBehaviour
    {
        public static GameController CurrentInstance
        {
            get
            {
                if(!currentInstance)
                {
                    currentInstance = GameObject.FindObjectOfType<GameController>();
                }

                return currentInstance;
            }
        }
        private static GameController currentInstance;
    }
}
