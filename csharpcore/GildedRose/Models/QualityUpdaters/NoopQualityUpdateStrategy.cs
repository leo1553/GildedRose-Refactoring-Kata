using System;

namespace GildedRoseKata.Models.QualityUpdaters {
    public class NoopQualityUpdateStrategy : IQualityUpdateStrategy {
        /// <summary>
        /// Nada acontece.
        /// </summary>
        public void UpdateQuality(Item item) {
            if(item is null)
                throw new ArgumentNullException(nameof(item));
        }
    }
}
