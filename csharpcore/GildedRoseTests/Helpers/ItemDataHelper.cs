using GildedRoseKata.Enums;
using GildedRoseKata.Models;

namespace GildedRoseTests.Helpers {
    public static class ItemDataHelper {
        public static IItemModel GetItem1() {
            return new ItemModel() {
                Name = "foo",
                SellIn = 0,
                Quality = 0,
                QualityLimiterStrategy = QualityLimiterStrategies.Default,
                QualityUpdateStrategy = QualityUpdateStrategies.Noop,
                SellInUpdateStrategy = SellInUpdateStrategies.Noop
            };
        }

        public static IItemModel GetItem2() {
            return new ItemModel() {
                Name = "item-name",
                SellIn = 7,
                Quality = 16,
                QualityLimiterStrategy = QualityLimiterStrategies.Default,
                QualityUpdateStrategy = QualityUpdateStrategies.Decrease,
                SellInUpdateStrategy = SellInUpdateStrategies.Decrease
            };
        }

        public static IItemModel GetItem3() {
            return new ItemModel() {
                Name = "im-a-real-item",
                SellIn = 4,
                Quality = 2,
                QualityLimiterStrategy = QualityLimiterStrategies.Default,
                QualityUpdateStrategy = QualityUpdateStrategies.Increase,
                SellInUpdateStrategy = SellInUpdateStrategies.Decrease
            };
        }

        public static IItemModel GetItem4() {
            return new ItemModel() {
                Name = "a-legend",
                SellIn = 0,
                Quality = 80,
                QualityLimiterStrategy = QualityLimiterStrategies.Legendary,
                QualityUpdateStrategy = QualityUpdateStrategies.Noop,
                SellInUpdateStrategy = SellInUpdateStrategies.Noop
            };
        }

        public static IItemModel GetItem5() {
            return new ItemModel() {
                Name = "out-of-quality",
                SellIn = -1,
                Quality = 0,
                QualityLimiterStrategy = QualityLimiterStrategies.Default,
                QualityUpdateStrategy = QualityUpdateStrategies.Conjured,
                SellInUpdateStrategy = SellInUpdateStrategies.Decrease
            };
        }

        public static IItemModel GetItem6() {
            return new ItemModel() {
                Name = "too-much-quality",
                SellIn = -1,
                Quality = 50,
                QualityLimiterStrategy = QualityLimiterStrategies.Default,
                QualityUpdateStrategy = QualityUpdateStrategies.Increase,
                SellInUpdateStrategy = SellInUpdateStrategies.Decrease
            };
        }

        public static IItemModel GetItem7() {
            return new ItemModel() {
                Name = "hype-train",
                SellIn = 0,
                Quality = 50,
                QualityLimiterStrategy = QualityLimiterStrategies.Default,
                QualityUpdateStrategy = QualityUpdateStrategies.Hype,
                SellInUpdateStrategy = SellInUpdateStrategies.Decrease
            };
        }
    }
}
