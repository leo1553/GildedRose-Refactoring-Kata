using GildedRoseKata.Enums;

namespace GildedRoseKata.Models {
    public class ProgramOptions : IProgramOptions {
        public LogStrategies LogStrategy { get; set; }
        public int DaysToSimulate { get; set; } = 30;
    }
}
