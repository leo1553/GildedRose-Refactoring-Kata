using GildedRoseKata.Enums;
using GildedRoseKata.Models;

namespace GildedRoseKata.Services {
    public class QualityLimiterFactory : StrategyFactoryBase<QualityLimiterStrategies, IQualityLimiterStrategy>, IQualityLimiterFactory {
        public QualityLimiterFactory() : base(QualityLimiterStrategies.Default) {
        }
    }
}
