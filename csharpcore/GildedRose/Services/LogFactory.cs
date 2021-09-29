using GildedRoseKata.Enums;
using GildedRoseKata.Models;

namespace GildedRoseKata.Services {
    public class LogFactory : StrategyFactoryBase<LogStrategies, ILogStrategy>, ILogFactory {
        public LogFactory() : base(LogStrategies.Default) {
        }
    }
}
