using GildedRoseKata.Models;
using GildedRoseKata.Models.LateQualityUpdaters;
using Xunit;

namespace GildedRoseTests.ModelTests.LateQualityUpdaterTests {
    public class NoopLateQualityUpdateStrategyTests {
        /// <summary>
        /// DADO    um item qualquer
        /// QUANDO  <see cref="NoopLateQualityUpdateStrategy.LateUpdateQuality(Item)"/> for chamado
        /// ENTÃO   item.Quality deve ser mantido.
        /// </summary>
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(50)]
        [InlineData(51)]
        public void LateUpdateQuality_QualityDeveSerMantido(int quality) {
            Item item = new Item() {
                Quality = quality
            };
            NoopLateQualityUpdateStrategy noopLateQualityUpdateStrategy = new NoopLateQualityUpdateStrategy();
            noopLateQualityUpdateStrategy.LateUpdateQuality(item);
            Assert.Equal(quality, item.Quality);
        }
    }
}
