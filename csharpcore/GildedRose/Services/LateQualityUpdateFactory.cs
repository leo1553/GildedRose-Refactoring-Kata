using GildedRoseKata.Enums;
using GildedRoseKata.Models;

namespace GildedRoseKata.Services {
    public class LateQualityUpdateFactory : StrategyFactoryBase<QualityUpdateStrategies, ILateQualityUpdateStrategy>, ILateQualityUpdateFactory {
        public LateQualityUpdateFactory() : base(QualityUpdateStrategies.Noop) {
        }
    }
}
