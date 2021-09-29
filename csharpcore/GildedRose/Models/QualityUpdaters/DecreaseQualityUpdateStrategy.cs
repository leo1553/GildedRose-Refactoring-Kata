using GildedRoseKata.Enums;
using GildedRoseKata.Utils;
using System;

namespace GildedRoseKata.Models.QualityUpdaters {
    [RegisterStrategy(For = QualityUpdateStrategies.Decrease)]
    public class DecreaseQualityUpdateStrategy : IQualityUpdateStrategy {
        protected int Multiplier { get; set; } = 1;

        /// <summary>
        /// Reduz <paramref name="item"/>.Quality de acordo com <paramref name="item"/>.SellIn:<br/>
        /// - Caso o prazo de venda tenha expirado (<paramref name="item"/>.SellIn menor ou igual a zero), reduz a qualidade 
        ///   em <see cref="DecreaseQualityUpdateStrategy.Multiplier"/> vezes dois;<br/>
        /// - Senão, reduz a qualidade em <see cref="DecreaseQualityUpdateStrategy.Multiplier"/>.
        /// </summary>
        public void UpdateQuality(Item item) {
            if(item is null)
                throw new ArgumentNullException(nameof(item));
            if(item.SellIn <= 0)
                item.Quality -= 2 * this.Multiplier;
            else
                item.Quality -= this.Multiplier;
        }
    }
}
