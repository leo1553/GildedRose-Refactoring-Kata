namespace GildedRoseKata.Models {
    public class ItemData : IItemData {
        public Item Item { get; set; }
        public ILateQualityUpdateStrategy LateQualityUpdateStrategy { get; set; }
        public IQualityLimiterStrategy QualityLimiterStrategy { get; set; }
        public IQualityUpdateStrategy QualityUpdateStrategy { get; set; }
        public ISellInUpdateStrategy SellInUpdateStrategy { get; set; }
    }
}
