using GildedRoseKata.Enums;
using GildedRoseKata.Models.Logs;
using GildedRoseKata.Services;
using System;
using Xunit;

namespace GildedRoseTests.ServiceTests {
    public class LogFactoryTests {
        /// <summary>
        /// DADO    um <see cref="LogStrategies"/> válido
        /// QUANDO  LogFactory.CreateInstance é chamado com este <see cref="LogStrategies"/>
        /// ENTÃO   deve ser retornado a estratégia específica do enumerador.
        /// </summary>
        [Theory]
        [InlineData(LogStrategies.Default, typeof(DefaultLogStrategy))]
        [InlineData(LogStrategies.Minimal, typeof(MinimalLogStrategy))]
        [InlineData(LogStrategies.Legacy, typeof(LegacyLogStrategy))]
        public void CreateInstance_ComValoresValidos(LogStrategies logStrategy, Type expectedType) {
            LogFactory logFactory = new LogFactory();
            object result = logFactory.CreateInstance(logStrategy);
            Assert.IsType(expectedType, result);
        }

        /// <summary>
        /// DADO    um <see cref="LogStrategies"/> válido
        /// QUANDO  LogFactory.CreateInstance é chamado com este <see cref="LogStrategies"/>
        /// ENTÃO   deve ser retornado a estratégia padrão.
        /// </summary>
        [Theory]
        [InlineData((LogStrategies)100)]
        [InlineData((LogStrategies)999)]
        public void CreateInstance_ComValoresInvalidos(LogStrategies logStrategy) {
            LogFactory logFactory = new LogFactory();
            object result = logFactory.CreateInstance(logStrategy);
            Assert.IsType<DefaultLogStrategy>(result);
        }
    }
}
