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
                  $"              GildedRose              {Environment.NewLine}"
                + $"| day | name      | sellIn | quality |{Environment.NewLine}"
                + $"|-----|-----------|--------|---------|{Environment.NewLine}"
                + $"|   3 | foo       |      0 |       0 |{Environment.NewLine}"
                + $"|   3 | item-name |      7 |      16 |{Environment.NewLine}"
                + Environment.NewLine;
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
