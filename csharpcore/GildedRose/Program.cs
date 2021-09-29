using GildedRoseKata.Data;
using GildedRoseKata.Models;
using GildedRoseKata.Services;
using System;

namespace GildedRoseKata {
    public class Program {
        public static void Main(string[] args) {
            Console.WriteLine("OMGHAI!");

            IDataSource dataSource = new JsonDataSource();
            IItemDataFactory itemFactory = new ItemDataFactory(
                new LateQualityUpdateFactory(),
                new QualityLimiterFactory(),
                new QualityUpdateFactory(),
                new SellInUpdateFactory()
            );

            var app = new GildedRose(dataSource, itemFactory);

            for(var i = 0; i < 31; i++) {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                foreach(Item item in app.ItemDatas.Keys) {
                    Console.WriteLine(item.Name + ", " + item.SellIn + ", " + item.Quality);
                }
                Console.WriteLine("");
                app.UpdateQuality();
            }
        }
    }
}
