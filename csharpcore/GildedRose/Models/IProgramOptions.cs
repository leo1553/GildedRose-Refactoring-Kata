using GildedRoseKata.Enums;

namespace GildedRoseKata.Models {
    public interface IProgramOptions {
        LogStrategies LogStrategy { get; set; }
        int DaysToSimulate { get; set; }
    }
}
