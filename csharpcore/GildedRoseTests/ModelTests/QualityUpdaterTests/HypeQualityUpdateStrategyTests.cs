using GildedRoseKata.Models;
using GildedRoseKata.Models.QualityUpdaters;
using Xunit;

namespace GildedRoseTests.ModelTests.QualityUpdaterTests {
    public class HypeQualityUpdateStrategyTests {
        private void TestUpdateQuality(int sellIn, int quality, int expectedQuality) {
            Item item = new Item() {
                SellIn = sellIn,
                Quality = quality
            };
            HypeQualityUpdateStrategy hypeQualityUpdateStrategy = new HypeQualityUpdateStrategy();
            hypeQualityUpdateStrategy.UpdateQuality(item);
            Assert.Equal(expectedQuality, item.Quality);
        }

        /// <summary>
        /// DADO    que item.SellIn seja menor que zero
        /// QUANDO  <see cref="HypeQualityUpdateStrategy.UpdateQuality(Item)"/> for chamado
        /// ENTÃO   item.Quality deve ser zero.
        /// </summary>
        [Theory]
        [InlineData(-1, 1,  0)]
        [InlineData(-2, 2,  0)]
        [InlineData(-3, 25, 0)]
        [InlineData(-9, 50, 0)]
        public void UpdateQuality_DeveRetornarZero(int sellIn, int quality, int expectedQuality) {
            this.TestUpdateQuality(sellIn, quality, expectedQuality);
        }

        /// <summary>
        /// DADO    que item.SellIn seja maior ou igual a zero e menor ou igual a cinco
        /// QUANDO  <see cref="HypeQualityUpdateStrategy.UpdateQuality(Item)"/> for chamado
        /// ENTÃO   item.Quality deve incrementado em três.
        /// </summary>
        [Theory]
        [InlineData(0,  0,  3)]
        [InlineData(1,  1,  4)]
        [InlineData(2,  2,  5)]
        [InlineData(3, 10, 13)]
        [InlineData(4, 25, 28)]
        [InlineData(5, 50, 53)]
        public void UpdateQuality_DeveRetornarTresAMais(int sellIn, int quality, int expectedQuality) {
            this.TestUpdateQuality(sellIn, quality, expectedQuality);
        }

        /// <summary>
        /// DADO    que item.SellIn seja maior que cinco e menor ou igual a dez
        /// QUANDO  <see cref="HypeQualityUpdateStrategy.UpdateQuality(Item)"/> for chamado
        /// ENTÃO   item.Quality deve incrementado em dois.
        /// </summary>
        [Theory]
        [InlineData(6,  1,   3)]
        [InlineData(7,  2,   4)]
        [InlineData(8,  10, 12)]
        [InlineData(9,  25, 27)]
        [InlineData(10, 50, 52)]
        public void UpdateQuality_DeveRetornarDoisAMais(int sellIn, int quality, int expectedQuality) {
            this.TestUpdateQuality(sellIn, quality, expectedQuality);
        }

        /// <summary>
        /// DADO    itemData.Item item.SellIn seja maior que dez
        /// QUANDO  <see cref="HypeQualityUpdateStrategy.UpdateQuality(Item)"/> for chamado
        /// ENTÃO   item.Quality deve incrementado em um.
        /// </summary>
        [Theory]
        [InlineData(11,  1,   2)]
        [InlineData(20,  2,   3)]
        [InlineData(60,  10, 11)]
        [InlineData(99,  25, 26)]
        public void UpdateQuality_DeveRetornarUmAMais(int sellIn, int quality, int expectedQuality) {
            this.TestUpdateQuality(sellIn, quality, expectedQuality);
        }
    }
}
