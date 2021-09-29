using GildedRoseKata.Enums;
using GildedRoseKata.Models;
using GildedRoseKata.Models.QualityUpdaters;

namespace GildedRoseKata.Services {
    public class QualityUpdateFactory : StrategyFactoryBase<QualityUpdateStrategies, IQualityUpdateStrategy>, IQualityUpdateFactory {
        public QualityUpdateFactory() : base(QualityUpdateStrategies.Noop) {
            this.Register(QualityUpdateStrategies.Noop, () => new NoopQualityUpdateStrategy());
            this.Register(QualityUpdateStrategies.Decrease, () => new DecreaseQualityUpdateStrategy());
            this.Register(QualityUpdateStrategies.Increase, () => new IncreaseQualityUpdateStrategy());
            this.Register(QualityUpdateStrategies.Hype, () => new HypeQualityUpdateStrategy());
            this.Register(QualityUpdateStrategies.Conjured, () => new ConjuredQualityUpdateStrategy());

            // TODO
            // OCP pede ajuda
        }
    }
}
