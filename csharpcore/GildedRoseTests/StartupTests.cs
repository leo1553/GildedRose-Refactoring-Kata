using Xunit;
using GildedRoseKata;
using GildedRoseKata.Models;
using GildedRoseTests.Mocks;
using System;
using System.Text;
using System.IO;

namespace GildedRoseTests {
    public class StartupTests {
        private Startup GetStartup() {
            Startup startup = new Startup(
                GildedRoseHelper.GetMockGildedRose(new IItemModel[] { }),
                new LogFactoryMock());
            IProgramOptions options = new ProgramOptions() {
                DaysToSimulate = 3
            };
            startup.Prepare(options);
            return startup;
        }

        [Fact]
        public void Run_ValidarSaida() {
            // Como os testes são processados em paralelo, é necessário garantir
            // a segurança desta condição de corrida, senão o teste falhará
            lock(Console.In) {
                StringBuilder stringBuilder = new StringBuilder();
                Console.SetOut(new StringWriter(stringBuilder));
                Startup startup = this.GetStartup();
                startup.Run();
                string consoleOutput = stringBuilder.ToString();
                string expectedOutput =
                      $"Begin{Environment.NewLine}"
                    + $"Log Day 0{Environment.NewLine}"
                    + $"Log Day 1{Environment.NewLine}"
                    + $"Log Day 2{Environment.NewLine}"
                    + $"Log Day 3{Environment.NewLine}"
                    + $"Finish{Environment.NewLine}";
                Assert.Equal(expectedOutput, consoleOutput);
            }
        }
    }
}
