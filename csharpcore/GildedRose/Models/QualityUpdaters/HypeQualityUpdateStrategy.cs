using System;

namespace GildedRoseKata.Models.QualityUpdaters {
    public class HypeQualityUpdateStrategy : IQualityUpdateStrategy {
        /// <summary>
        /// Aumenta <paramref name="item"/>.Quality de acordo com <paramref name="item"/>.SellIn:<br/>
        /// - Caso <paramref name="item"/>.SellIn seja menor que zero, <paramref name="item"/>.Quality se torna zero;<br/>
        /// - Senão, caso <paramref name="item"/>.SellIn seja menor ou igual a cinco, <paramref name="item"/>.Quality aumenta em três;<br/>
        /// - Senão, caso <paramref name="item"/>.SellIn seja menor ou igual a dez, <paramref name="item"/>.Quality aumenta em dois;<br/>
        /// - Senão, <paramref name="item"/>.SellIn aumenta em um.
        /// </summary>
        public void UpdateQuality(Item item) {
            if(item is null)
                throw new ArgumentNullException(nameof(item));
            if(item.SellIn < 0)
                item.Quality = 0;
            else if(item.SellIn < 6)
                item.Quality += 3;
            else if(item.SellIn < 11)
                item.Quality += 2;
            else
                item.Quality++;
        }
    }
}
