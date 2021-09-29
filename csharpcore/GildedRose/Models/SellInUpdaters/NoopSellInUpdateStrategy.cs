using System;

namespace GildedRoseKata.Models.SellInUpdaters {
    public class NoopSellInUpdateStrategy : ISellInUpdateStrategy {
        /// <summary>
        /// Nada acontece.
        /// </summary>
        public void UpdateSellIn(Item item) {
            if(item is null)
                throw new ArgumentNullException(nameof(item));
        }
    }
}
