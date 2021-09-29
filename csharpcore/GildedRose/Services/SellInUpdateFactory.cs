using GildedRoseKata.Enums;
using GildedRoseKata.Models;
using GildedRoseKata.Models.SellInUpdaters;

namespace GildedRoseKata.Services {
    public class SellInUpdateFactory : StrategyFactoryBase<SellInUpdateStrategies, ISellInUpdateStrategy>, ISellInUpdateFactory {
        public SellInUpdateFactory() : base(SellInUpdateStrategies.Noop) {
            this.Register(SellInUpdateStrategies.Noop, () => new NoopSellInUpdateStrategy());
            this.Register(SellInUpdateStrategies.Decrease, () => new DecreaseSellInUpdateStrategy());
        }
    }
}
