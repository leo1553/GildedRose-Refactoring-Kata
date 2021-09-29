using GildedRoseKata.Enums;

namespace GildedRoseKata.Models {
    public class ItemModel : IItemModel {
        public string Name { get; set; }
        public int SellIn { get; set; }
        public int Quality { get; set; }
        public QualityLimiterStrategies QualityLimiterStrategy { get; set; }
        public QualityUpdateStrategies QualityUpdateStrategy { get; set; }
        public SellInUpdateStrategies SellInUpdateStrategy { get; set; }
    }
}
