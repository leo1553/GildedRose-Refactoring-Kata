using GildedRoseKata.Enums;
using GildedRoseKata.Models;
using GildedRoseKata.Services;

namespace GildedRoseTests.Mocks {
    public class LateQualityUpdateFactoryMock : ILateQualityUpdateFactory {
        public ILateQualityUpdateStrategy CreateInstance(QualityUpdateStrategies qualityUpdateStrategies) {
            return new LateQualityUpdateStrategyMock();
        }
    }
}
