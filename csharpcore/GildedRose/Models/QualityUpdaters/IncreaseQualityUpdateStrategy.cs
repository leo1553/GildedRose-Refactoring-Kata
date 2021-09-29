namespace GildedRoseKata.Models.QualityUpdaters {
    public class IncreaseQualityUpdateStrategy : DecreaseQualityUpdateStrategy {
        public IncreaseQualityUpdateStrategy() {
            this.Multiplier = -1;
        }
    }
}
