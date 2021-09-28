using GildedRoseKata.Enums;

namespace GildedRoseKata.Models {
    public interface IItemModel : IItem {
        QualityLimiterStrategies QualityLimiterStrategy { get; set; }
        QualityUpdateStrategies QualityUpdateStrategy { get; set; }
        SellInUpdateStrategies SellInUpdateStrategy { get; set; }
    }
}
