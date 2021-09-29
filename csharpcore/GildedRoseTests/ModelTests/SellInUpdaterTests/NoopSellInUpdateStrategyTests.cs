using GildedRoseKata.Models;
using GildedRoseKata.Models.SellInUpdaters;
using Xunit;

namespace GildedRoseTests.ModelTests.SellInUpdaterTests {
    public class NoopSellInUpdateStrategyTests {
        /// <summary>
        /// DADO    um item qualquer
        /// QUANDO  <see cref="NoopSellInUpdateStrategy.UpdateSellIn(Item)"/> for chamado
        /// ENTÃO   item.SellIn deve ser mantido.
        /// </summary>
        [Theory]
        [InlineData(-1)]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(50)]
        [InlineData(51)]
        public void UpdateSellIn_SellInDeveSerMantido(int sellIn) {
            Item item = new Item() {
                SellIn = sellIn
            };
            NoopSellInUpdateStrategy noopSellInUpdateStrategy = new NoopSellInUpdateStrategy();
            noopSellInUpdateStrategy.UpdateSellIn(item);
            Assert.Equal(sellIn, item.SellIn);
        }
    }
}
