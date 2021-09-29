using GildedRoseKata;
using GildedRoseKata.Data;
using GildedRoseKata.Models;
using GildedRoseKata.Services;
using GildedRoseTests.Mocks;
using System.Collections.Generic;

namespace GildedRoseTests {
    public static class GildedRoseHelper {
        public static IItemDataFactory GetRealItemDataFactory() {
            return new ItemDataFactory(
                new LateQualityUpdateFactory(),
                new QualityLimiterFactory(),
                new QualityUpdateFactory(),
                new SellInUpdateFactory()
            );
        }

        public static IItemDataFactory GetMockItemDataFactory() {
            return new ItemDataFactory(
                new LateQualityUpdateFactoryMock(),
                new QualityLimiterFactoryMock(),
                new QualityUpdateFactoryMock(),
                new SellInUpdateFactoryMock()
            );
        }

        public static IDataSource GetMockDataSource(IEnumerable<IItemModel> items) {
            return new DataSourceMock() {
                Items = items
            };
        }

        public static GildedRose GetMockGildedRose(IEnumerable<IItemModel> items) {
            return new GildedRose(
                GildedRoseHelper.GetMockDataSource(items),
                GildedRoseHelper.GetMockItemDataFactory());
        }

        public static GildedRose GetRealGildedRose(IEnumerable<IItemModel> items) {
            return new GildedRose(
                GildedRoseHelper.GetMockDataSource(items),
                GildedRoseHelper.GetRealItemDataFactory());
        }
    }
}
