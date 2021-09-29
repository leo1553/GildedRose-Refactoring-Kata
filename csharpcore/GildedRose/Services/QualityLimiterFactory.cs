using GildedRoseKata.Enums;
using GildedRoseKata.Models;
using GildedRoseKata.Models.QualityLimiters;

namespace GildedRoseKata.Services {
    public class QualityLimiterFactory : StrategyFactoryBase<QualityLimiterStrategies, IQualityLimiterStrategy>, IQualityLimiterFactory {
        public QualityLimiterFactory() : base(QualityLimiterStrategies.Default) {
            this.Register(QualityLimiterStrategies.Default, () => new DefaultQualityLimiterStrategy());
            this.Register(QualityLimiterStrategies.Legendary, () => new LegendaryQualityLimiterStrategy());
        }
    }
}
