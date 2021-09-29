using GildedRoseKata.Models;
using System;

namespace GildedRoseTests.Mocks {
    public class LateQualityUpdateStrategyMock : ILateQualityUpdateStrategy {
        public void LateUpdateQuality(Item item) {
            throw new NotImplementedException();
        }
    }
}
