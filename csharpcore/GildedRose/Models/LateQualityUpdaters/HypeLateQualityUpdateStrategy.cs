using System;

namespace GildedRoseKata.Models.LateQualityUpdaters {
    public class HypeLateQualityUpdateStrategy : ILateQualityUpdateStrategy {
        /// <summary>
        /// Caso o tempo de venda tenha expirado, definir <paramref name="item"/>.Quality para zero.
        /// </summary>
        public void LateUpdateQuality(Item item) {
            if(item is null)
                throw new ArgumentNullException(nameof(item));
            if(item.SellIn < 0)
                item.Quality = 0;
        }
    }
}
