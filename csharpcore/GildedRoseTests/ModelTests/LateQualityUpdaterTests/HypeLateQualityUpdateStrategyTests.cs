using GildedRoseKata.Models;
using GildedRoseKata.Models.LateQualityUpdaters;
using Xunit;

namespace GildedRoseTests.ModelTests.LateQualityUpdaterTests {
    public class HypeLateQualityUpdateStrategyTests {
        /// <summary>
        /// DADO    que o prazo de venda tenha expirado
        /// QUANDO  <see cref="HypeLateQualityUpdateStrategy.LateUpdateQuality(Item)"/> for chamado
        /// ENTÃO   item.Quality deve ser zerado.
        /// </summary>
        [Theory]
        [InlineData(-1,  -1)]
        [InlineData(-2,   0)]
        [InlineData(-5,   1)]
        [InlineData(-9,  50)]
        [InlineData(-99, 51)]
        public void LateUpdateQuality_QualityDeveSerZerado(int sellIn, int quality) {
            Item item = new Item() {
                Quality = quality,
                SellIn = sellIn
            };
            HypeLateQualityUpdateStrategy hypeLateQualityUpdateStrategy = new HypeLateQualityUpdateStrategy();
            hypeLateQualityUpdateStrategy.LateUpdateQuality(item);
            Assert.Equal(0, item.Quality);
        }

        /// <summary>
        /// DADO    que o prazo de venda não tenha expirado
        /// QUANDO  <see cref="HypeLateQualityUpdateStrategy.LateUpdateQuality(Item)"/> for chamado
        /// ENTÃO   item.Quality deve ser mantido.
        /// </summary>
        [Theory]
        [InlineData(1,  -1)]
        [InlineData(2,   0)]
        [InlineData(5,   1)]
        [InlineData(9,  50)]
        [InlineData(99, 51)]
        public void LateUpdateQuality_QualityDeveSerMantido(int sellIn, int quality) {
            Item item = new Item() {
                Quality = quality,
                SellIn = sellIn
            };
            HypeLateQualityUpdateStrategy hypeLateQualityUpdateStrategy = new HypeLateQualityUpdateStrategy();
            hypeLateQualityUpdateStrategy.LateUpdateQuality(item);
            Assert.Equal(quality, item.Quality);
        }
    }
}
