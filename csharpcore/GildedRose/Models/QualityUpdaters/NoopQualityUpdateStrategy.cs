using GildedRoseKata.Enums;
using GildedRoseKata.Utils;
using System;

namespace GildedRoseKata.Models.QualityUpdaters {
    [RegisterStrategy(For = QualityUpdateStrategies.Noop)]
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
