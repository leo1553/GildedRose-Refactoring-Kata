using GildedRoseKata.Enums;
using GildedRoseKata.Utils;
using System;

namespace GildedRoseKata.Models.SellInUpdaters {
    [RegisterStrategy(For = SellInUpdateStrategies.Decrease)]
    public class DecreaseSellInUpdateStrategy : ISellInUpdateStrategy {
        public void UpdateSellIn(Item item) {
            if(item is null)
                throw new ArgumentNullException(nameof(item));
            item.SellIn--;
        }
    }
}
