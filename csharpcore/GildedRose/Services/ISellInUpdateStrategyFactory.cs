using GildedRoseKata.Enums;
using GildedRoseKata.Models;

namespace GildedRoseKata.Services {
    public interface ISellInUpdateStrategyFactory {
        ISellInUpdateStrategy CreateInstance(SellInUpdateStrategies sellInUpdateStrategy);
    }
}
