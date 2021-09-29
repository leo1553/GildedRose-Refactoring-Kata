﻿using Xunit;
using System.Collections.Generic;
using GildedRoseKata;
using GildedRoseKata.Models;

namespace GildedRoseTests {
    public class GildedRoseTest {
        [Fact]
        public void Foo() {
            IList<Item> Items = new List<Item> { new Item { Name = "foo", SellIn = 0, Quality = 0 } };
            GildedRose app = new GildedRose(Items);
            app.UpdateQuality();
            Assert.Equal("foo", Items[0].Name);
        }
    }
}
