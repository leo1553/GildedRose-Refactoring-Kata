using GildedRoseKata.Enums;
using GildedRoseKata.Models;
using GildedRoseKata.Services;

namespace GildedRoseTests.Mocks {
    public class QualityLimiterFactoryMock : IQualityLimiterFactory {
        public IQualityLimiterStrategy CreateInstance(QualityLimiterStrategies qualityLimiterStrategy) {
            return new QualityLimiterStrategyMock();
        }
    }
}
