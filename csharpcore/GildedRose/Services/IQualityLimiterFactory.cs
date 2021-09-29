using GildedRoseKata.Enums;
using GildedRoseKata.Models;

namespace GildedRoseKata.Services {
    public interface IQualityLimiterFactory {
        IQualityLimiterStrategy CreateInstance(QualityLimiterStrategies qualityLimiterStrategy);
    }
}
