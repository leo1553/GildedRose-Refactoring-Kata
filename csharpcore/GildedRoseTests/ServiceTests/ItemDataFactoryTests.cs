using GildedRoseKata.Enums;
using GildedRoseKata.Models;
using GildedRoseKata.Services;
using GildedRoseTests.Mocks;
using Xunit;

namespace GildedRoseTests.ServiceTests {
    public class ItemDataFactoryTests {
        /// <summary>
        /// DADO    que exista um <see cref="IItemModel"/>
        /// QUANDO  <see cref="ItemDataFactory.CreateFrom(IItemModel)"/> for chamado com este <see cref="IItemModel"/>
        /// ENTÃO   os dados atribuídos ao <see cref="IItemData"/> retornado devem estar corretos.
        /// </summary>
        [Fact]
        public void CreateFrom_ValidarItem() {
            ItemDataFactory itemFactory = new ItemDataFactory(
                new LateQualityUpdateFactoryMock(),
                new QualityLimiterFactoryMock(),
                new QualityUpdateFactoryMock(),
                new SellInUpdateFactoryMock()
            );
            ItemModel sourceModel = new ItemModel() {
                Name = "test",
                Quality = 123,
                SellIn = 321,
                QualityLimiterStrategy = QualityLimiterStrategies.Default,
                QualityUpdateStrategy = QualityUpdateStrategies.Noop,
                SellInUpdateStrategy = SellInUpdateStrategies.Noop
            };
            IItemData itemData = itemFactory.CreateFrom(sourceModel);
            Assert.Equal(sourceModel.Name, itemData.Item.Name);
            Assert.Equal(sourceModel.Quality, itemData.Item.Quality);
            Assert.Equal(sourceModel.SellIn, itemData.Item.SellIn);
            Assert.IsType<LateQualityUpdateStrategyMock>(itemData.LateQualityUpdateStrategy);
            Assert.IsType<QualityLimiterStrategyMock>(itemData.QualityLimiterStrategy);
            Assert.IsType<QualityUpdateStrategyMock>(itemData.QualityUpdateStrategy);
            Assert.IsType<SellInUpdateStrategyMock>(itemData.SellInUpdateStrategy);
        }
    }
}
