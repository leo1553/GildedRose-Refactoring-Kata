namespace GildedRoseKata.Models {
    public interface ILateQualityUpdateStrategy {
        void LateUpdateQuality(IItemData item);
    }
}
