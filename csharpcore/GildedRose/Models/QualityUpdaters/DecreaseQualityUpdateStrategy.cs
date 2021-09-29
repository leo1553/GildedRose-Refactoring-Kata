using System;

namespace GildedRoseKata.Models.QualityUpdaters {
    public class DecreaseQualityUpdateStrategy : IQualityUpdateStrategy {
        /// <summary>
        /// Reduz <paramref name="item"/>.Quality de acordo com <paramref name="item"/>.SellIn:<br/>
        /// - Caso o prazo de venda tenha expirado (<paramref name="item"/>.SellIn menor que zero), reduz a qualidade em dois;<br/>
        /// - Senão, reduz a qualidade em um.
        /// </summary>
        public void UpdateQuality(Item item) {
            if(item is null)
                throw new ArgumentNullException(nameof(item));
            if(item.SellIn < 0)
                item.Quality -= 2;
            else
                item.Quality--;
        }
    }
}
