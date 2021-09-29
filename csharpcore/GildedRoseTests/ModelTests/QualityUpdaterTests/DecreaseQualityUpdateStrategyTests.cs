using GildedRoseKata.Models;
using GildedRoseKata.Models.QualityUpdaters;
using Xunit;

namespace GildedRoseTests.ModelTests.QualityUpdaterTests {
    public class DecreaseQualityUpdateStrategyTests {
        private void TestUpdateQuality(int sellIn, int quality, int expectedQuality) {
            Item item = new Item() {
                Quality = quality,
                SellIn = sellIn
            };
            DecreaseQualityUpdateStrategy decreaseQualityUpdateStrategy = new DecreaseQualityUpdateStrategy();
            decreaseQualityUpdateStrategy.UpdateQuality(item);
            Assert.Equal(expectedQuality, item.Quality);
        }

        /// <summary>
        /// DADO    que item.SellIn seja maior ou igual a zero
        /// QUANDO  <see cref="DecreaseQualityUpdateStrategy.UpdateQuality(Item)"/> for chamado
        /// ENTÃO   item.Quality deve ser reduzido em um.
        /// </summary>
        [Theory]
        [InlineData(0, 0,  -1)]
        [InlineData(3, 1,   0)]
        [InlineData(7, 2,   1)]
        [InlineData(9, 50, 49)]
        public void UpdateQuality_DeveRetornarUmAMenos(int sellIn, int quality, int expectedQuality) {
            this.TestUpdateQuality(sellIn, quality, expectedQuality);
        }

        /// <summary>
        /// DADO    que item.SellIn menor que zero
        /// QUANDO  <see cref="DecreaseQualityUpdateStrategy.UpdateQuality(Item)"/> for chamado
        /// ENTÃO   item.Quality deve ser reduzido em dois.
        /// </summary>
        [Theory]
        [InlineData(-1,  0, -2)]
        [InlineData(-3,  1, -1)]
        [InlineData(-7,  2,  0)]
        [InlineData(-9, 50, 48)]
        public void UpdateQuality_DeveRetornarDoisAMenos(int sellIn, int quality, int expectedQuality) {
            this.TestUpdateQuality(sellIn, quality, expectedQuality);
        }
    }
}
