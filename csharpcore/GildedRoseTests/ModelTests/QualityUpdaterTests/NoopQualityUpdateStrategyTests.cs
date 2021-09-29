using GildedRoseKata.Models;
using GildedRoseKata.Models.QualityUpdaters;
using Xunit;

namespace GildedRoseTests.ModelTests.QualityUpdaterTests {
    public class NoopQualityUpdateStrategyTests {
        /// <summary>
        /// DADO    um item qualquer
        /// QUANDO  <see cref="NoopQualityUpdateStrategy.UpdateQuality(Item)"/> for chamado
        /// ENTÃO   item.Quality deve ser mantido.
        /// </summary>
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(50)]
        [InlineData(51)]
        public void UpdateQuality_QualityDeveSerMantido(int quality) {
            Item item = new Item() {
                Quality = quality
            };
            NoopQualityUpdateStrategy noopQualityUpdateStrategy = new NoopQualityUpdateStrategy();
            noopQualityUpdateStrategy.UpdateQuality(item);
            Assert.Equal(quality, item.Quality);
        }
    }
}
