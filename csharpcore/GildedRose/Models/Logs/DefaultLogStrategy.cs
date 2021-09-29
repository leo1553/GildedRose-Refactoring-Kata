using ConsoleTableExt;
using GildedRoseKata.Enums;
using GildedRoseKata.Utils;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GildedRoseKata.Models.Logs {
    [RegisterStrategy(For = LogStrategies.Default)]
    public class DefaultLogStrategy : ILogStrategy {
        private List<List<object>> rows;

        public void Begin(TextWriter writer) {
            if(writer is null)
                throw new ArgumentNullException(nameof(writer));
            this.rows = new List<List<object>>();
        }

        public void Finish(TextWriter writer) {
            if(writer is null)
                throw new ArgumentNullException(nameof(writer));
            StringBuilder stringBuilder = ConsoleTableBuilder
                .From(this.rows)
                .WithTitle("GildedRose")
                .WithColumn("day", "name", "sellIn", "quality")
                .WithTextAlignment(new Dictionary<int, TextAligntment>() {
                    { 0, TextAligntment.Right },
                    { 2, TextAligntment.Right },
                    { 3, TextAligntment.Right },
                })
                .WithFormat(ConsoleTableBuilderFormat.MarkDown)
                .Export();
            writer.WriteLine(stringBuilder.ToString());
            this.rows = null;
        }

        public void Log(TextWriter writer, int day, GildedRose gildedRose) {
            if(writer is null)
                throw new ArgumentNullException(nameof(writer));
            if(gildedRose is null)
                throw new ArgumentNullException(nameof(gildedRose));
            foreach(Item item in gildedRose.ItemDatas.Keys) {
                List<object> columns = new List<object>();
                columns.AddRange(new object[] { day, item.Name, item.SellIn, item.Quality });
                this.rows.Add(columns);
            }
        }
    }
}
