using GildedRoseKata.Models;
using GildedRoseKata.Models.SellInUpdaters;
using Xunit;

namespace GildedRoseTests.ModelTests.SellInUpdaterTests {
    public class DecreaseSellInUpdateStrategyTests {
        /// <summary>
        /// DADO    um item qualquer
        /// QUANDO  <see cref="DecreaseSellInUpdateStrategy.UpdateSellIn(Item)"/> for chamado
        /// ENTÃO   item.SellIn deve ser reduzido em um.
        /// </summary>
        [Theory]
        [InlineData(0,  -1)]
        [InlineData(1,   0)]
        [InlineData(2,   1)]
        [InlineData(50, 49)]
        public void UpdateSellIn_DeveRetornarUmAMenos(int sellIn, int expectedSellIn) {
            Item item = new Item() {
                SellIn = sellIn
            };
            DecreaseSellInUpdateStrategy decreaseSellInUpdateStrategy = new DecreaseSellInUpdateStrategy();
            decreaseSellInUpdateStrategy.UpdateSellIn(item);
            Assert.Equal(expectedSellIn, item.SellIn);
        }
    }
}
