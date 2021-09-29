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
    public class LegacyLogStrategyTests {
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
        public void Begin_SaudacaoDeveEstarPresente() {
            LegacyLogStrategy legacyLogStrategy = new LegacyLogStrategy();
            StringBuilder builder = new StringBuilder();
            using(TextWriter writer = new StringWriter(builder)) {
                legacyLogStrategy.Begin(writer);
            }
            string result = builder.ToString();
            Assert.Equal($"OMGHAI!{Environment.NewLine}", result);
        }

        [Fact]
        public void Finish_NadaDeveSerEscrito() {
            LegacyLogStrategy legacyLogStrategy = new LegacyLogStrategy();
            StringBuilder builder = new StringBuilder();
            using(TextWriter writer = new StringWriter(builder)) {
                legacyLogStrategy.Finish(writer);
            }
            string result = builder.ToString();
            Assert.Equal("", result);
        }

        [Fact]
        public void Log_OsDadosDosItensDevemSerEscritos() {
            LegacyLogStrategy legacyLogStrategy = new LegacyLogStrategy();
            GildedRose gildedRose = this.GetGildedRose();
            StringBuilder builder = new StringBuilder();
            using(TextWriter writer = new StringWriter(builder)) {
                legacyLogStrategy.Log(writer, 2, gildedRose);
            }
            string result = builder.ToString();
            string expectedResult =
                  $"-------- day 2 --------{Environment.NewLine}"
                + $"name, sellIn, quality{Environment.NewLine}"
                + $"foo, 0, 0{Environment.NewLine}"
                + $"item-name, 7, 16{Environment.NewLine}"
                + Environment.NewLine;
            Assert.Equal(expectedResult, result);
        }
    }
}
