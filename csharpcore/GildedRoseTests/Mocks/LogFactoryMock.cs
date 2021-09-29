using GildedRoseKata.Enums;
using GildedRoseKata.Models;
using GildedRoseKata.Services;

namespace GildedRoseTests.Mocks {
    public class LogFactoryMock : ILogFactory {
        public ILogStrategy CreateInstance(LogStrategies logStrategy) {
            return new LogStrategyMock();
        }
    }
}
