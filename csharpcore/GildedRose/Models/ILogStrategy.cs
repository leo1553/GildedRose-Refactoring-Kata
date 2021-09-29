using System.IO;

namespace GildedRoseKata.Models {
    public interface ILogStrategy {
        void Begin(TextWriter writer);
        void Finish(TextWriter writer);
        void Log(TextWriter writer, int day, GildedRose gildedRose);
    }
}
