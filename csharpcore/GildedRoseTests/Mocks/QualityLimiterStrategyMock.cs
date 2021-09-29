using GildedRoseKata.Models;
using System;

namespace GildedRoseTests.Mocks {
    public class QualityLimiterStrategyMock : IQualityLimiterStrategy {
        public int Limit(int quality) {
            throw new NotImplementedException();
        }
    }
}
