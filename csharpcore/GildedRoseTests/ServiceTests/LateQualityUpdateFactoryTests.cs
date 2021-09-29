using GildedRoseKata.Enums;
using GildedRoseKata.Models.LateQualityUpdaters;
using GildedRoseKata.Services;
using System;
using Xunit;

namespace GildedRoseTests.ServiceTests {
    public class LateQualityUpdateFactoryTests {
        /// <summary>
        /// DADO    um <see cref="QualityUpdateStrategies"/> válido
        /// QUANDO  LateQualityUpdateFactory.CreateInstance é chamado com este <see cref="QualityUpdateStrategies"/>
        /// ENTÃO   deve ser retornado a estratégia específica do enumerador.
        /// </summary>
        [Theory]
        [InlineData(QualityUpdateStrategies.Noop, typeof(NoopLateQualityUpdateStrategy))]
        [InlineData(QualityUpdateStrategies.Hype, typeof(HypeLateQualityUpdateStrategy))]
        public void CreateInstance_ComValoresValidos(QualityUpdateStrategies qualityUpdateStrategy, Type expectedType) {
            LateQualityUpdateFactory lateQualityUpdateFactory = new LateQualityUpdateFactory();
            object result = lateQualityUpdateFactory.CreateInstance(qualityUpdateStrategy);
            Assert.Equal(expectedType, result.GetType());
        }

        /// <summary>
        /// DADO    um <see cref="QualityUpdateStrategies"/> inválido
        /// QUANDO  LateQualityUpdateFactory.CreateInstance é chamado com este <see cref="QualityUpdateStrategies"/>
        /// ENTÃO   deve ser retornado a estratégia padrão.
        /// </summary>
        [Theory]
        [InlineData(QualityUpdateStrategies.Decrease)]
        [InlineData(QualityUpdateStrategies.Increase)]
        [InlineData((QualityUpdateStrategies)100)]
        [InlineData((QualityUpdateStrategies)999)]
        public void CreateInstance_ComValoresInvalidos(QualityUpdateStrategies qualityUpdateStrategy) {
            LateQualityUpdateFactory lateQualityUpdateFactory = new LateQualityUpdateFactory();
            object result = lateQualityUpdateFactory.CreateInstance(qualityUpdateStrategy);
            Assert.Equal(typeof(NoopLateQualityUpdateStrategy), result.GetType());
        }
    }
}
