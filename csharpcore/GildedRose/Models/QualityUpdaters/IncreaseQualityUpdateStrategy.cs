using GildedRoseKata.Enums;
using GildedRoseKata.Utils;

namespace GildedRoseKata.Models.QualityUpdaters {
    [RegisterStrategy(For = QualityUpdateStrategies.Increase)]
    public class IncreaseQualityUpdateStrategy : DecreaseQualityUpdateStrategy {
        public IncreaseQualityUpdateStrategy() {
            this.Multiplier = -1;
        }
    }
}
