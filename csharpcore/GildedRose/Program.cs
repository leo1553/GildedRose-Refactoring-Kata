using Autofac;
using GildedRoseKata.Data;
using GildedRoseKata.Models;
using GildedRoseKata.Services;
using GildedRoseKata.Utils;

namespace GildedRoseKata {
    public static class Program {
        private static IProgramOptions Options { get; set; }
        private static IContainer Container { get; set; }

        public static void Main(string[] args) {
            Program.GetOptions(args);
            Program.BuildContainer();
            Program.Run();
        }

        private static void GetOptions(string[] args) {
            Program.Options = ParameterParser.GetOptions(args);
        }

        private static void BuildContainer() {
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
            containerBuilder.RegisterType<LogFactory>()
                            .As<ILogFactory>()
                            .SingleInstance();
            // App
            containerBuilder.RegisterType<Startup>();
            containerBuilder.RegisterType<GildedRose>();

            Program.Container = containerBuilder.Build();
        }

        private static void Run() {
            Startup startup = Program.Container.Resolve<Startup>();
            startup.Prepare(Program.Options);
            startup.Run();
        }
    }
}
