using GildedRoseKata;
using GildedRoseKata.Models;
using GildedRoseKata.Models.Logs;
using GildedRoseTests.Helpers;
using System;
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
                  $"1{Environment.NewLine}"
                + $"\"foo\" 0 0{Environment.NewLine}"
                + $"\"item-name\" 7 16{Environment.NewLine}";
            Assert.Equal(expectedResult, result);
        }
    }
}
