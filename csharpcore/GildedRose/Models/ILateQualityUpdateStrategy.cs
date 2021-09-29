namespace GildedRoseKata.Models {
    public interface ILateQualityUpdateStrategy {
        void LateUpdateQuality(/* IItem */ Item item);
    }
}
