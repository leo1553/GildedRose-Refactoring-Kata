using System;

namespace GildedRoseKata.Models.QualityUpdaters {
    public class IncreaseQualityUpdateStrategy : IQualityUpdateStrategy {
        /// <summary>
        /// Incrementa <paramref name="item"/>.Quality em um.
        /// </summary>
        public void UpdateQuality(Item item) {
            if(item is null)
                throw new ArgumentNullException(nameof(item));
            item.Quality++;
        }
    }
}
