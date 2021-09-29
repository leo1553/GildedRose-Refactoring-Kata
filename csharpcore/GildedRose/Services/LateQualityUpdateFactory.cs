using GildedRoseKata.Enums;
using GildedRoseKata.Models;
using GildedRoseKata.Models.LateQualityUpdaters;

namespace GildedRoseKata.Services {
    public class LateQualityUpdateFactory : StrategyFactoryBase<QualityUpdateStrategies, ILateQualityUpdateStrategy>, ILateQualityUpdateFactory {
        public LateQualityUpdateFactory() : base(QualityUpdateStrategies.Noop) {
            this.Register(QualityUpdateStrategies.Noop, () => new NoopLateQualityUpdateStrategy());
            this.Register(QualityUpdateStrategies.Hype, () => new HypeLateQualityUpdateStrategy());
        }
    }
}
