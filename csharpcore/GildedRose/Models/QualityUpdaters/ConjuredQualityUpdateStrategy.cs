namespace GildedRoseKata.Models.QualityUpdaters {
    public class ConjuredQualityUpdateStrategy : DecreaseQualityUpdateStrategy {
        public ConjuredQualityUpdateStrategy() {
            this.Multiplier = 2;
        }
    }
}
