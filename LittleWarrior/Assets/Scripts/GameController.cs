namespace Assets.Scripts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine;
    using Input;

    public class GameController : MonoBehaviour
    {
        public static GameController CurrentInstance
        {
            get
            {
                if(!_currentInstance)
                {
                    _currentInstance = GameObject.FindObjectOfType<GameController>();
                }

                return _currentInstance;
            }
        }
        private static GameController _currentInstance;
        public void ExecuteInput(HashSet<int> touchedNodes)
        {
            var patterns = PatternUtil.ParseInput(touchedNodes);
            var str = "Executed pattern: ";
            foreach(var p in patterns)
            {
                str += p.ToString();
                str += ',';
            }
            Debug.Log(str);
        }
    }
}
