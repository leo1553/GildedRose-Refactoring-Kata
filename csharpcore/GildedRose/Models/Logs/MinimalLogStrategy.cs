using GildedRoseKata.Enums;
using GildedRoseKata.Utils;
using System;
using System.IO;

namespace GildedRoseKata.Models.Logs {
    [RegisterStrategy(For = LogStrategies.Minimal)]
    public class MinimalLogStrategy : ILogStrategy {
        public void Begin(TextWriter writer) {
            if(writer is null)
                throw new ArgumentNullException(nameof(writer));
        }

        public void Finish(TextWriter writer) {
            if(writer is null)
                throw new ArgumentNullException(nameof(writer));
        }

        public void Log(TextWriter writer, int day, GildedRose gildedRose) {
            if(writer is null)
                throw new ArgumentNullException(nameof(writer));
            if(gildedRose is null)
                throw new ArgumentNullException(nameof(gildedRose));
            writer.WriteLine(day);
            foreach(Item item in gildedRose.ItemDatas.Keys)
                writer.WriteLine($"\"{item.Name}\" {item.SellIn} {item.Quality}");
        }
    }
}
