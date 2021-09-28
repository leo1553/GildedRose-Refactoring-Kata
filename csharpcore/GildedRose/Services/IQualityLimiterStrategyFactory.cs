using GildedRoseKata.Enums;
using GildedRoseKata.Models;

namespace GildedRoseKata.Services {
    public interface IQualityLimiterStrategyFactory {
        IQualityLimiterStrategy CreateInstance(QualityLimiterStrategies qualityLimiterStrategy);
    }
}
