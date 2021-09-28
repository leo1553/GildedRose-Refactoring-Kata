using GildedRoseKata.Models;

namespace GildedRoseKata.Services {
    public interface IItemDataFactory {
        IItemData CreateFrom(IItemModel itemModel);
    }
}
