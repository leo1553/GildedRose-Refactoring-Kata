using GildedRoseKata.Models;
using GildedRoseKata.Models.QualityUpdaters;
using Xunit;

namespace GildedRoseTests.ModelTests.QualityUpdaterTests {
    public class IncreaseQualityUpdateStrategyTests {
        /// <summary>
        /// DADO    que o tempo de venda não tenha expirado
        /// QUANDO  <see cref="IncreaseQualityUpdateStrategy.UpdateQuality(Item)"/> for chamado
        /// ENTÃO   item.Quality deve ser incrementado em um.
        /// </summary>
        [Theory]
        [InlineData(1,  -1,   0)]
        [InlineData(9,   0,   1)]
        [InlineData(20,  1,   2)]
        [InlineData(99,  50, 51)]
        public void UpdateQuality_DeveRetornarUmAMais(int sellIn, int quality, int expectedQuality) {
            Item item = new Item() {
                Quality = quality,
                SellIn = sellIn
            };
            IncreaseQualityUpdateStrategy increaseQualityUpdateStrategy = new IncreaseQualityUpdateStrategy();
            increaseQualityUpdateStrategy.UpdateQuality(item);
            Assert.Equal(expectedQuality, item.Quality);
        }

        /// <summary>
        /// DADO    que o tempo de venda tenha expirado
        /// QUANDO  <see cref="IncreaseQualityUpdateStrategy.UpdateQuality(Item)"/> for chamado
        /// ENTÃO   item.Quality deve ser incrementado em dois.
        /// </summary>
        [Theory]
        [InlineData(0,   -1,   1)]
        [InlineData(-1,   0,   2)]
        [InlineData(-10,  1,   3)]
        [InlineData(-99,  50, 52)]
        public void UpdateQuality_DeveRetornarDoisAMais(int sellIn, int quality, int expectedQuality) {
            Item item = new Item() {
                Quality = quality,
                SellIn = sellIn
            };
            IncreaseQualityUpdateStrategy increaseQualityUpdateStrategy = new IncreaseQualityUpdateStrategy();
            increaseQualityUpdateStrategy.UpdateQuality(item);
            Assert.Equal(expectedQuality, item.Quality);
        }
    }
}
