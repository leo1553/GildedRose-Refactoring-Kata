using GildedRoseKata.Enums;
using GildedRoseKata.Models;

namespace GildedRoseKata.Services {
    public interface IQualityUpdateStrategyFactory {
        IQualityUpdateStrategy CreateInstance(QualityUpdateStrategies qualityUpdateStrategy);
    }
}
