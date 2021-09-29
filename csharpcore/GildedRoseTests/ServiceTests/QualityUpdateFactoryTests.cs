using GildedRoseKata.Enums;
using GildedRoseKata.Models.QualityUpdaters;
using GildedRoseKata.Services;
using System;
using Xunit;

namespace GildedRoseTests.ServiceTests {
    public class QualityUpdateFactoryTests {
        /// <summary>
        /// DADO    um <see cref="QualityUpdateStrategies"/> válido
        /// QUANDO  QualityUpdateFactory.CreateInstance é chamado com este <see cref="QualityUpdateStrategies"/>
        /// ENTÃO   deve ser retornado a estratégia específica do enumerador.
        /// </summary>
        [Theory]
        [InlineData(QualityUpdateStrategies.Noop, typeof(NoopQualityUpdateStrategy))]
        [InlineData(QualityUpdateStrategies.Decrease, typeof(DecreaseQualityUpdateStrategy))]
        [InlineData(QualityUpdateStrategies.Increase, typeof(IncreaseQualityUpdateStrategy))]
        [InlineData(QualityUpdateStrategies.Hype, typeof(HypeQualityUpdateStrategy))]
        public void CreateInstance_ComValoresValidos(QualityUpdateStrategies qualityUpdateStrategy, Type expectedType) {
            QualityUpdateFactory qualityUpdateFactory = new QualityUpdateFactory();
            object result = qualityUpdateFactory.CreateInstance(qualityUpdateStrategy);
            Assert.Equal(expectedType, result.GetType());
        }

        /// <summary>
        /// DADO    um <see cref="QualityUpdateStrategies"/> inválido
        /// QUANDO  QualityUpdateStrategyFactory.CreateInstance é chamado com este <see cref="QualityUpdateStrategies"/>
        /// ENTÃO   deve ser retornado a estratégia padrão.
        /// </summary>
        [Theory]
        [InlineData((QualityUpdateStrategies)100)]
        [InlineData((QualityUpdateStrategies)999)]
        public void CreateInstance_ComValoresInvalidos(QualityUpdateStrategies qualityUpdateStrategy) {
            QualityUpdateFactory qualityUpdateFactory = new QualityUpdateFactory();
            object result = qualityUpdateFactory.CreateInstance(qualityUpdateStrategy);
            Assert.Equal(typeof(NoopQualityUpdateStrategy), result.GetType());
        }
    }
}
