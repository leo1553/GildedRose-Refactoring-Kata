using GildedRoseKata;
using GildedRoseKata.Models;
using GildedRoseKata.Models.Logs;
using GildedRoseTests.Helpers;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xunit;

namespace GildedRoseTests.ModelTests.LogTests {
    public class MinimalLogStrategyTests {
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
            MinimalLogStrategy minimalLogStrategy = new MinimalLogStrategy();
            StringBuilder builder = new StringBuilder();
            using(TextWriter writer = new StringWriter(builder)) {
                minimalLogStrategy.Begin(writer);
            }
            string result = builder.ToString();
            Assert.Equal("", result);
        }

        [Fact]
        public void Finish_NadaDeveSerEscrito() {
            MinimalLogStrategy minimalLogStrategy = new MinimalLogStrategy();
            StringBuilder builder = new StringBuilder();
            using(TextWriter writer = new StringWriter(builder)) {
                minimalLogStrategy.Finish(writer);
            }
            string result = builder.ToString();
            Assert.Equal("", result);
        }

        [Fact]
        public void Log_OsDadosDosItensDevemSerEscritos() {
            MinimalLogStrategy minimalLogStrategy = new MinimalLogStrategy();
            GildedRose gildedRose = this.GetGildedRose();
            StringBuilder builder = new StringBuilder();
            using(TextWriter writer = new StringWriter(builder)) {
                minimalLogStrategy.Log(writer, 1, gildedRose);
            }
            string result = builder.ToString();
            string expectedResult =
                  "1\r\n"
                + "\"foo\" 0 0\r\n"
                + "\"item-name\" 7 16\r\n";
            Assert.Equal(expectedResult, result);
        }
    }
}
