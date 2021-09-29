using GildedRoseKata;
using GildedRoseKata.Models;
using System.IO;

namespace GildedRoseTests.Mocks {
    public class LogStrategyMock : ILogStrategy {
        public void Begin(TextWriter writer) {
            writer.WriteLine("Begin");
        }

        public void Finish(TextWriter writer) {
            writer.WriteLine("Finish");
        }

        public void Log(TextWriter writer, int day, GildedRose gildedRose) {
            writer.WriteLine($"Log Day {day}");
        }
    }
}
