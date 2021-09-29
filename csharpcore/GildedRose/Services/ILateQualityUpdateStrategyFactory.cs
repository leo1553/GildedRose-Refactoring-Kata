using GildedRoseKata.Enums;
using GildedRoseKata.Models;

namespace GildedRoseKata.Services {
    public interface ILateQualityUpdateStrategyFactory {
        ILateQualityUpdateStrategy CreateInstance(QualityUpdateStrategies qualityLimiterStrategy);
    }
}
