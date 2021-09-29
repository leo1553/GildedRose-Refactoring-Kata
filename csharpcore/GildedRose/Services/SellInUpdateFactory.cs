using GildedRoseKata.Enums;
using GildedRoseKata.Models;

namespace GildedRoseKata.Services {
    public class SellInUpdateFactory : StrategyFactoryBase<SellInUpdateStrategies, ISellInUpdateStrategy>, ISellInUpdateFactory {
        public SellInUpdateFactory() : base(SellInUpdateStrategies.Noop) {
        }
    }
}
