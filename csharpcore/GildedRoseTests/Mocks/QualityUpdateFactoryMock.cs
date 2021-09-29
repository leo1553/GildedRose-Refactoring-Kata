using GildedRoseKata.Enums;
using GildedRoseKata.Models;
using GildedRoseKata.Services;

namespace GildedRoseTests.Mocks {
    public class QualityUpdateFactoryMock : IQualityUpdateFactory {
        public IQualityUpdateStrategy CreateInstance(QualityUpdateStrategies qualityUpdateStrategy) {
            return new QualityUpdateStrategyMock();
        }
    }
}
