using GildedRoseKata.Models.QualityLimiters;
using Xunit;

namespace GildedRoseTests.ModelTests.QualityLimiterTests {
    public class DefaultQualityLimiterStrategyTests {
        private void TestLimit(int quality, int expectedQuality) {
            DefaultQualityLimiterStrategy defaultQualityLimiterStrategy = new DefaultQualityLimiterStrategy();
            int resultQuality = defaultQualityLimiterStrategy.Limit(quality);
            Assert.Equal(expectedQuality, resultQuality);
        }

        /// <summary>
        /// DADO    que <paramref name="quality"/> seja menor que zero
        /// QUANDO  <see cref="DefaultQualityLimiterStrategy.Limit(int)"/> for chamado
        /// ENTÃO   deve ser retornado zero.
        /// </summary>
        [Theory]
        [InlineData(-50, 0)]
        [InlineData(-10, 0)]
        [InlineData(-1,  0)]
        [InlineData(0,   0)]
        public void Limit_NaoDeveSerMenorQueZero(int quality, int expectedQuality) {
            this.TestLimit(quality, expectedQuality);
        }

        /// <summary>
        /// DADO    que <paramref name="quality"/> seja maior ou igual zero e menor ou igual cinquenta
        /// QUANDO  <see cref="DefaultQualityLimiterStrategy.Limit(int)"/> for chamado
        /// ENTÃO   deve ser retornado <paramref name="quality"/>.
        /// </summary>
        [Theory]
        [InlineData(0,   0)]
        [InlineData(1,   1)]
        [InlineData(49, 49)]
        [InlineData(50, 50)]
        public void Limit_DentroDosLimites(int quality, int expectedQuality) {
            this.TestLimit(quality, expectedQuality);
        }

        /// <summary>
        /// DADO    que <paramref name="quality"/> seja mairo que cinquenta
        /// QUANDO  <see cref="DefaultQualityLimiterStrategy.Limit(int)"/> for chamado
        /// ENTÃO   deve ser retornado 50.
        /// </summary>
        [Theory]
        [InlineData(50, 50)]
        [InlineData(51, 50)]
        [InlineData(75, 50)]
        [InlineData(99, 50)]
        public void Limit_NaoDeveSerMaiorQueCinquenta(int quality, int expectedQuality) {
            this.TestLimit(quality, expectedQuality);
        }
    }
}
