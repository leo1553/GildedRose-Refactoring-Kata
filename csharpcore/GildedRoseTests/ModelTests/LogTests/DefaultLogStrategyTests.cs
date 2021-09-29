using GildedRoseKata;
using GildedRoseKata.Models;
using GildedRoseKata.Models.Logs;
using GildedRoseTests.Helpers;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace GildedRoseTests.ModelTests.LogTests {
    public class DefaultLogStrategyTests {
        private IEnumerable<IItemModel> GetItems() {
            return new IItemModel[] {
                ItemDataHelper.GetItem1(),
                ItemDataHelper.GetItem2()
            };
        }

        private GildedRose GetGildedRose() {
            return GildedRoseHelper.GetMockGildedRose(
                this.GetItems());
        }

        [Fact]
        public void Begin_NadaDeveSerEscrito() {
            DefaultLogStrategy defaultLogStrategy = new DefaultLogStrategy();
            StringBuilder builder = new StringBuilder();
            using(TextWriter writer = new StringWriter(builder)) {
                defaultLogStrategy.Begin(writer);
            }
            string result = builder.ToString();
            Assert.Equal("", result);
        }

        [Fact]
        public void Finish_OsDadosDosItensDevemSerEscritos() {
            DefaultLogStrategy defaultLogStrategy = new DefaultLogStrategy();
            GildedRose gildedRose = this.GetGildedRose();
            StringBuilder builder = new StringBuilder();
            using(TextWriter writer = new StringWriter(builder)) {
                defaultLogStrategy.Begin(writer);
                defaultLogStrategy.Log(writer, 3, gildedRose);
                defaultLogStrategy.Finish(writer);
            }
            string result = builder.ToString();
            string expectedResult =
                  "              GildedRose              \r\n"
                + "| day | name      | sellIn | quality |\r\n"
                + "|-----|-----------|--------|---------|\r\n"
                + "|   3 | foo       |      0 |       0 |\r\n"
                + "|   3 | item-name |      7 |      16 |\r\n"
                + "\r\n";
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void Log_NadaDeveSerEscrito() {
            DefaultLogStrategy defaultLogStrategy = new DefaultLogStrategy();
            GildedRose gildedRose = this.GetGildedRose();
            StringBuilder builder = new StringBuilder();
            using(TextWriter writer = new StringWriter(builder)) {
                defaultLogStrategy.Begin(writer);
                defaultLogStrategy.Log(writer, 1, gildedRose);
            }
            string result = builder.ToString();
            Assert.Equal("", result);
        }
    }
}
