namespace GildedRoseKata.Models {
    public interface IQualityLimiterStrategy {
        int Limit(int quality);
    }
}
