using Xunit;
using System;
using System.IO;
using System.Text;
using ApprovalTests;
using ApprovalTests.Reporters;
using GildedRoseKata;

namespace GildedRoseTests {
    [UseReporter(typeof(DiffReporter))]
    public class ApprovalTest {
        [Fact]
        public void ThirtyDays() {
            // Como os testes são processados em paralelo, é necessário garantir
            // a segurança desta condição de corrida, senão o teste falhará
            lock(Console.Out) {
                var stringBuilder = new StringBuilder();
                Console.SetOut(new StringWriter(stringBuilder));

                Program.Main(new string[] { "--log=Legacy" });
                var consoleOutput = stringBuilder.ToString();

                Approvals.Verify(consoleOutput);
            }
        }
    }
}
