using GildedRoseKata.Models;
using System.Collections.Generic;

namespace GildedRoseKata.Data {
    public interface IDataSource {
        IEnumerable<IItemModel> Items { get; }
    }
}
