using GildedRoseKata.Enums;
using GildedRoseKata.Utils;
using System;

namespace GildedRoseKata.Models.LateQualityUpdaters {
    [RegisterStrategy(For = QualityUpdateStrategies.Noop)]
    public class NoopLateQualityUpdateStrategy : ILateQualityUpdateStrategy {
        /// <summary>
        /// Nada acontece.
        /// </summary>
        public void LateUpdateQuality(Item item) {
            if(item is null)
                throw new ArgumentNullException(nameof(item));
        }
    }
}
