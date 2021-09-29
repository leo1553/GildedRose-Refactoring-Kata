using GildedRoseKata.Enums;
using GildedRoseKata.Models;

namespace GildedRoseKata.Services {
    public interface ILogFactory {
        ILogStrategy CreateInstance(LogStrategies logStrategy);
    }
}
