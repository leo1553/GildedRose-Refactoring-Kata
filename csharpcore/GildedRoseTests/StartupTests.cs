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
                      "Begin\r\n"
                    + "Log Day 0\r\n"
                    + "Log Day 1\r\n"
                    + "Log Day 2\r\n"
                    + "Log Day 3\r\n"
                    + "Finish\r\n";
                Assert.Equal(expectedOutput, consoleOutput);
            }
        }
    }
}
