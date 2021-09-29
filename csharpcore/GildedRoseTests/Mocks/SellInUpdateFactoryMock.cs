using GildedRoseKata.Enums;
using GildedRoseKata.Models;
using GildedRoseKata.Services;

namespace GildedRoseTests.Mocks {
    public class SellInUpdateFactoryMock : ISellInUpdateFactory {
        public ISellInUpdateStrategy CreateInstance(SellInUpdateStrategies sellInUpdateStrategy) {
            return new SellInUpdateStrategyMock();
        }
    }
}
