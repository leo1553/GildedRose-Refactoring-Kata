using Xunit;
using GildedRoseKata;
using GildedRoseKata.Models;
using GildedRoseKata.Data;
using GildedRoseTests.Mocks;
using GildedRoseKata.Services;
using GildedRoseKata.Enums;
using System.Linq;

namespace GildedRoseTests {
    public class GildedRoseTest {
        private IItemDataFactory GetItemDataFactory() {
            return new ItemDataFactory(
                new LateQualityUpdateFactory(),
                new QualityLimiterFactory(),
                new QualityUpdateFactory(),
                new SellInUpdateFactory()
            );
        }

        [Fact]
        public void Foo() {
            IDataSource dataSource = new DataSourceMock() {
                Items = new ItemModel[] {
                    new ItemModel() {
                        Name = "foo", 
                        SellIn = 0,
                        Quality = 0,
                        QualityLimiterStrategy = QualityLimiterStrategies.Default,
                        QualityUpdateStrategy = QualityUpdateStrategies.Noop,
                        SellInUpdateStrategy = SellInUpdateStrategies.Noop
                    }
                }
            };
            IItemDataFactory itemFactory = this.GetItemDataFactory();
            GildedRose app = new GildedRose(dataSource, itemFactory);
            app.UpdateQuality();
            Assert.Single(app.ItemDatas);
            // Item 1
            IItemData itemData = app.ItemDatas.Values.First();
            Assert.Equal("foo", itemData.Item.Name);
            Assert.Equal(0, itemData.Item.SellIn);
            Assert.Equal(0, itemData.Item.Quality);
        }
    }
}
