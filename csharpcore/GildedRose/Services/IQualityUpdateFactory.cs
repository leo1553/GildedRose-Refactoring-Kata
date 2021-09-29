using GildedRoseKata.Enums;
using GildedRoseKata.Models;

namespace GildedRoseKata.Services {
    public interface IQualityUpdateFactory {
        IQualityUpdateStrategy CreateInstance(QualityUpdateStrategies qualityUpdateStrategy);
    }
}
