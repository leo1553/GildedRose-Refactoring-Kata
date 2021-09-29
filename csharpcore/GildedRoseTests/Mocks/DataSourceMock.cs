using GildedRoseKata.Data;
using GildedRoseKata.Models;
using System.Collections.Generic;

namespace GildedRoseTests.Mocks {
    public class DataSourceMock : IDataSource {
        public IEnumerable<IItemModel> Items { get; set; }
    }
}
