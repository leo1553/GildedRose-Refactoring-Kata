using GildedRoseKata.Models;
using GildedRoseKata.Services;
using System;

namespace GildedRoseKata {
    public class Startup {
        private readonly GildedRose gildedRose;
        private readonly ILogFactory logFactory;

        private IProgramOptions options;
        private ILogStrategy logStrategy;

        public Startup(GildedRose gildedRose, ILogFactory logFactory) {
            this.gildedRose = gildedRose;
            this.logFactory = logFactory;
        }

        public void Prepare(IProgramOptions options) {
            this.options = options;
            this.logStrategy = this.logFactory.CreateInstance(options.LogStrategy);
        }

        public void Run() {
            this.logStrategy.Begin(Console.Out);
            for(var i = 0; i <= this.options.DaysToSimulate; i++) {
                this.Log(i);
                this.gildedRose.UpdateQuality();
            }
            this.logStrategy.Finish(Console.Out);
        }

        private void Log(int day) {
            this.logStrategy.Log(Console.Out, day, this.gildedRose);
        }
    }
}
