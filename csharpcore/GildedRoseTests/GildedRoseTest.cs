using Xunit;
using GildedRoseKata;
using GildedRoseKata.Models;
using System.Linq;
using System.Collections.Generic;
using GildedRoseTests.Helpers;

namespace GildedRoseTests {
    public class GildedRoseTest {
        [Fact]
        public void GildedRose_ValidarExistenciaDosItensNoItemDatas() {
            IEnumerable<IItemModel> items = new IItemModel[] {
                ItemDataHelper.GetItem1(),
                ItemDataHelper.GetItem3(),
            };
            GildedRose gildedRose = GildedRoseHelper.GetRealGildedRose(items);
            Assert.Equal(items.Count(), gildedRose.ItemDatas.Count);
            // Item 1
            IItemData itemData = gildedRose.ItemDatas.Values.First();
            Assert.Equal("foo", itemData.Item.Name);
            Assert.Equal(0, itemData.Item.SellIn);
            Assert.Equal(0, itemData.Item.Quality);
            // Item 3
            itemData = gildedRose.ItemDatas.Values.ElementAt(1);
            Assert.Equal("im-a-real-item", itemData.Item.Name);
            Assert.Equal(4, itemData.Item.SellIn);
            Assert.Equal(2, itemData.Item.Quality);
        }

        [Fact]
        public void UpdateQuality_ValidarAlteracaoDeQuality() {
            IEnumerable<IItemModel> items = new IItemModel[] {
                ItemDataHelper.GetItem2(),
                ItemDataHelper.GetItem3(),
            };
            GildedRose gildedRose = GildedRoseHelper.GetRealGildedRose(items);
            gildedRose.UpdateQuality();
            // Item 2
            IItemData itemData = gildedRose.ItemDatas.Values.First();
            Assert.Equal(15, itemData.Item.Quality);
            // Item 3
            itemData = gildedRose.ItemDatas.Values.ElementAt(1);
            Assert.Equal(3, itemData.Item.Quality);
        }

        [Fact]
        public void UpdateQuality_ValidarAlteracaoDeSellIn() {
            IEnumerable<IItemModel> items = new IItemModel[] {
                ItemDataHelper.GetItem2(),
                ItemDataHelper.GetItem4(),
            };
            GildedRose gildedRose = GildedRoseHelper.GetRealGildedRose(items);
            gildedRose.UpdateQuality();
            // Item 2
            IItemData itemData = gildedRose.ItemDatas.Values.First();
            Assert.Equal(6, itemData.Item.SellIn);
            // Item 4
            itemData = gildedRose.ItemDatas.Values.ElementAt(1);
            Assert.Equal(0, itemData.Item.SellIn);
        }

        [Fact]
        public void UpdateQuality_ValidarQualityAposAlteracaoDeSellIn() {
            // O unico caso que possui LateQualityUpdateStrategy é o Hype
            // no entanto, o QualityUpdateStrategy já deixa o valor em zero.
            // Logo não há caso um bom caso de teste para esta etapa.
            // TODO: Criar Mock para testar este caso.
            IEnumerable<IItemModel> items = new IItemModel[] {
                ItemDataHelper.GetItem7()
            };
            GildedRose gildedRose = GildedRoseHelper.GetRealGildedRose(items);
            gildedRose.UpdateQuality();
            // Item 7
            IItemData itemData = gildedRose.ItemDatas.Values.First();
            Assert.Equal(0, itemData.Item.Quality);
        }

        [Fact]
        public void UpdateQuality_ValidarLimitesDeQuality() {
            IEnumerable<IItemModel> items = new IItemModel[] {
                ItemDataHelper.GetItem4(),
                ItemDataHelper.GetItem5(),
                ItemDataHelper.GetItem6(),
            };
            GildedRose gildedRose = GildedRoseHelper.GetRealGildedRose(items);
            gildedRose.UpdateQuality();
            // Item 4
            IItemData itemData = gildedRose.ItemDatas.Values.First();
            Assert.Equal(80, itemData.Item.Quality);
            // Item 5
            itemData = gildedRose.ItemDatas.Values.ElementAt(1);
            Assert.Equal(0, itemData.Item.Quality);
            // Item 6
            itemData = gildedRose.ItemDatas.Values.ElementAt(2);
            Assert.Equal(50, itemData.Item.Quality);
        }
    }
}
