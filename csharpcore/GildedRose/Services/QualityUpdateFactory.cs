using GildedRoseKata.Enums;
using GildedRoseKata.Models;

namespace GildedRoseKata.Services {
    public class QualityUpdateFactory : StrategyFactoryBase<QualityUpdateStrategies, IQualityUpdateStrategy>, IQualityUpdateFactory {
        public QualityUpdateFactory() : base(QualityUpdateStrategies.Noop) {
        }
    }
}
