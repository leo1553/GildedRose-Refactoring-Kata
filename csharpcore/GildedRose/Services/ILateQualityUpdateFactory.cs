using GildedRoseKata.Enums;
using GildedRoseKata.Models;

namespace GildedRoseKata.Services {
    public interface ILateQualityUpdateFactory {
        ILateQualityUpdateStrategy CreateInstance(QualityUpdateStrategies qualityLimiterStrategy);
    }
}
