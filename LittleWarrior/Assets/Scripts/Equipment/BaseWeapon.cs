namespace Assets.Scripts.Equipment
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Input;

    /// <summary>
    /// Base class for all weapons
    /// </summary>
    public abstract class BaseWeapon : BaseEquipment
    {
        /// <summary>
        /// Flips the pattern (used if the equipment is in off hand)
        /// </summary>
        public void FliPattern()
        {
            this.Patterns = this.Patterns.Select(pattern => pattern.GetOpposite()).ToList();
        }
    }
}
