using GildedRoseKata.Models.QualityLimiters;
using Xunit;

namespace GildedRoseTests.ModelTests.QualityLimiterTests {
    public class LegendaryQualityLimiterStrategyTests {
        /// <summary>
        /// DADO    qualquer numero para <paramref name="quality"/>
        /// QUANDO  <see cref="LegendaryQualityLimiterStrategy.Limit(int)"/> for chamado
        /// ENTÃO   deve ser retornado 80.
        /// </summary>
        [Theory]
        [InlineData(-50)]
        [InlineData(-10)]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(49)]
        [InlineData(50)]
        [InlineData(51)]
        [InlineData(75)]
        [InlineData(99)]
        public void Limit_DeveRetornarOitenta(int quality) {
            LegendaryQualityLimiterStrategy legendaryQualityLimiterStrategy = new LegendaryQualityLimiterStrategy();
            int resultQuality = legendaryQualityLimiterStrategy.Limit(quality);
            Assert.Equal(80, resultQuality);
        }
    }
}
