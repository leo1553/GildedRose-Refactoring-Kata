using GildedRoseKata.Enums;
using GildedRoseKata.Utils;
using System;
using System.IO;

namespace GildedRoseKata.Models.Logs {
    [RegisterStrategy(For = LogStrategies.Legacy)]
    public class LegacyLogStrategy : ILogStrategy {
        public void Begin(TextWriter writer) {
            if(writer is null)
                throw new ArgumentNullException(nameof(writer));
            writer.WriteLine("OMGHAI!");
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
            writer.WriteLine("-------- day " + day + " --------");
            writer.WriteLine("name, sellIn, quality");
            foreach(Item item in gildedRose.ItemDatas.Keys) {
                writer.WriteLine(item.Name + ", " + item.SellIn + ", " + item.Quality);
            }
            writer.WriteLine("");
        }
    }
}
