using GildedRoseKata.Enums;
using GildedRoseKata.Utils;
using System;

namespace GildedRoseKata.Models.SellInUpdaters {
    [RegisterStrategy(For = SellInUpdateStrategies.Noop)]
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
