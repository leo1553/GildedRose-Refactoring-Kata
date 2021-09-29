using GildedRoseKata.Enums;
using GildedRoseKata.Models;

namespace GildedRoseKata.Services {
    public interface ISellInUpdateFactory {
        ISellInUpdateStrategy CreateInstance(SellInUpdateStrategies sellInUpdateStrategy);
    }
}
