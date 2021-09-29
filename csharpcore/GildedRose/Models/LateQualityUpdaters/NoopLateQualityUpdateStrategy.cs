using System;

namespace GildedRoseKata.Models.LateQualityUpdaters {
    public class NoopLateQualityUpdateStrategy : ILateQualityUpdateStrategy {
        /// <summary>
        /// Nada acontece.
        /// </summary>
        public void LateUpdateQuality(Item item) {
            if(item is null)
                throw new ArgumentNullException(nameof(item));
        }
    }
}
