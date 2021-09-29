using System;

namespace GildedRoseKata.Models.SellInUpdaters {
    public class DecreaseSellInUpdateStrategy : ISellInUpdateStrategy {
        public void UpdateSellIn(Item item) {
            if(item is null)
                throw new ArgumentNullException(nameof(item));
            item.SellIn--;
        }
    }
}
