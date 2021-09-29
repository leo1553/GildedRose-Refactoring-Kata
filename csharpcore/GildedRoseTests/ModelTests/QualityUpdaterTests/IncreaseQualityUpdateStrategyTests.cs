using GildedRoseKata.Models;
using GildedRoseKata.Models.QualityUpdaters;
using Xunit;

namespace GildedRoseTests.ModelTests.QualityUpdaterTests {
    public class IncreaseQualityUpdateStrategyTests {
        /// <summary>
        /// DADO    um item qualquer
        /// QUANDO  <see cref="IncreaseQualityUpdateStrategy.UpdateQuality(Item)"/> for chamado
        /// ENTÃO   item.Quality deve ser incrementado em um.
        /// </summary>
        [Theory]
        [InlineData(-1,  0)]
        [InlineData(0,   1)]
        [InlineData(1,   2)]
        [InlineData(50, 51)]
        public void UpdateQuality_DeveRetornarUmAMais(int quality, int expectedQuality) {
            Item item = new Item() {
                Quality = quality
            };
            IncreaseQualityUpdateStrategy increaseQualityUpdateStrategy = new IncreaseQualityUpdateStrategy();
            increaseQualityUpdateStrategy.UpdateQuality(item);
            Assert.Equal(expectedQuality, item.Quality);
        }
    }
}
