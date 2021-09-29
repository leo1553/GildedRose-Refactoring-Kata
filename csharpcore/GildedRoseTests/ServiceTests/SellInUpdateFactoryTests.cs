using GildedRoseKata.Enums;
using GildedRoseKata.Models.SellInUpdaters;
using GildedRoseKata.Services;
using System;
using Xunit;

namespace GildedRoseTests.ServiceTests {
    public class SellInUpdateFactoryTests {
        /// <summary>
        /// DADO    um <see cref="SellInUpdateStrategies"/> válido
        /// QUANDO  SellInUpdateFactory.CreateInstance é chamado com este <see cref="SellInUpdateStrategies"/>
        /// ENTÃO   deve ser retornado a estratégia específica do enumerador.
        /// </summary>
        [Theory]
        [InlineData(SellInUpdateStrategies.Noop, typeof(NoopSellInUpdateStrategy))]
        [InlineData(SellInUpdateStrategies.Decrease, typeof(DecreaseSellInUpdateStrategy))]
        public void CreateInstance_ComValoresValidos(SellInUpdateStrategies sellInUpdateStrategy, Type expectedType) {
            SellInUpdateFactory sellInUpdateFactory = new SellInUpdateFactory();
            object result = sellInUpdateFactory.CreateInstance(sellInUpdateStrategy);
            Assert.Equal(expectedType, result.GetType());
        }

        /// <summary>
        /// DADO    um <see cref="SellInUpdateStrategies"/> inválido
        /// QUANDO  SellInUpdateStrategyFactory.CreateInstance é chamado com este <see cref="SellInUpdateStrategies"/>
        /// ENTÃO   deve ser retornado a estratégia padrão.
        /// </summary>
        [Theory]
        [InlineData((SellInUpdateStrategies)100)]
        [InlineData((SellInUpdateStrategies)999)]
        public void CreateInstance_ComValoresInvalidos(SellInUpdateStrategies sellInUpdateStrategy) {
            SellInUpdateFactory sellInUpdateFactory = new SellInUpdateFactory();
            object result = sellInUpdateFactory.CreateInstance(sellInUpdateStrategy);
            Assert.Equal(typeof(NoopSellInUpdateStrategy), result.GetType());
        }
    }
}
