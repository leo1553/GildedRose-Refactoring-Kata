using GildedRoseKata.Enums;
using GildedRoseKata.Utils;

namespace GildedRoseKata.Models.QualityUpdaters {
    [RegisterStrategy(For = QualityUpdateStrategies.Conjured)]
    public class ConjuredQualityUpdateStrategy : DecreaseQualityUpdateStrategy {
        public ConjuredQualityUpdateStrategy() {
            this.Multiplier = 2;
        }
    }
}
