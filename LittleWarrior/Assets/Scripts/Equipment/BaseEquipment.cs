namespace Assets.Scripts.Equipment
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using UnityEngine;
    using Input;
    using Resource;

    /// <summary>
    /// Base class for all equipments
    /// </summary>
    public abstract class BaseEquipment : MonoBehaviour
    {
        /// <summary>
        /// The patterns of the equipment
        /// </summary>
        public List<Pattern> Patterns { get; protected set; }

        /// <summary>
        /// How long it'll take for the item to be available again
        /// </summary>
        public float Cooldown;

        /// <summary>
        /// Executes the attack with the given slices
        /// </summary>
        /// <param name="consumedSlices">The slices that's consumed for the attack</param>
        protected abstract void ExecuteAttack(List<PizzaSlice> consumedSlices);
    }
}
