using Autofac;
using GildedRoseKata.Data;
using GildedRoseKata.Models;
using GildedRoseKata.Services;
using System;

namespace GildedRoseKata {
    public class Program {
        private IContainer Container { get; set; }
        private GildedRose GildedRose { get; set; }

        public static void Main(string[] args) => new Program(args).Run();

        public Program(string[] args) {
            Console.WriteLine("OMGHAI!");
            this.BuildContainer();
        }

        private void BuildContainer() {
            ContainerBuilder containerBuilder = new ContainerBuilder();
            // Dados
            containerBuilder.RegisterType<JsonDataSource>()
                            .As<IDataSource>();
            // Fabricas
            containerBuilder.RegisterType<ItemDataFactory>()
                            .As<IItemDataFactory>()
                            .SingleInstance();
            containerBuilder.RegisterType<LateQualityUpdateFactory>()
                            .As<ILateQualityUpdateFactory>()
                            .SingleInstance();
            containerBuilder.RegisterType<QualityLimiterFactory>()
                            .As<IQualityLimiterFactory>()
                            .SingleInstance();
            containerBuilder.RegisterType<QualityUpdateFactory>()
                            .As<IQualityUpdateFactory>()
                            .SingleInstance();
            containerBuilder.RegisterType<SellInUpdateFactory>()
                            .As<ISellInUpdateFactory>()
                            .SingleInstance();
            // App
            containerBuilder.RegisterType<GildedRose>();

            this.Container = containerBuilder.Build();
        }

        private void Run() {
            this.GildedRose = this.Container.Resolve<GildedRose>();
            this.Log();
        }

        private void Log() {
            for(var i = 0; i < 31; i++) {
                Console.WriteLine("-------- day " + i + " --------");
                Console.WriteLine("name, sellIn, quality");
                foreach(Item item in this.GildedRose.ItemDatas.Keys) {
                    Console.WriteLine(item.Name + ", " + item.SellIn + ", " + item.Quality);
                }
                Console.WriteLine("");
                this.GildedRose.UpdateQuality();
            }
        }
    }
}
