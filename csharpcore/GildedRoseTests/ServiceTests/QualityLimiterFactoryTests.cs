using GildedRoseKata.Enums;
using GildedRoseKata.Models.QualityLimiters;
using GildedRoseKata.Services;
using System;
using Xunit;

namespace GildedRoseTests.ServiceTests {
    public class QualityLimiterFactoryTests {
        /// <summary>
        /// DADO    um <see cref="QualityLimiterStrategies"/> válido
        /// QUANDO  QualityLimiterFactory.CreateInstance é chamado com este <see cref="QualityLimiterStrategies"/>
        /// ENTÃO   deve ser retornado a estratégia específica do enumerador
        /// </summary>
        [Theory]
        [InlineData(QualityLimiterStrategies.Default, typeof(DefaultQualityLimiterStrategy))]
        [InlineData(QualityLimiterStrategies.Legendary, typeof(LegendaryQualityLimiterStrategy))]
        public void CreateInstance_ComValoresValidos(QualityLimiterStrategies qualityLimiterStrategy, Type expectedType) {
            QualityLimiterFactory qualityLimiterFactory = new QualityLimiterFactory();
            object result = qualityLimiterFactory.CreateInstance(qualityLimiterStrategy);
            Assert.Equal(expectedType, result.GetType());
        }

        /// <summary>
        /// DADO    um <see cref="QualityLimiterStrategies"/> inválido
        /// QUANDO  QualityLimiterStrategyFactory.CreateInstance é chamado com este <see cref="QualityLimiterStrategies"/>
        /// ENTÃO   deve ser retornado a estratégia padrão
        /// </summary>
        [Theory]
        [InlineData((QualityLimiterStrategies)100)]
        [InlineData((QualityLimiterStrategies)999)]
        public void CreateInstance_ComValoresInvalidos(QualityLimiterStrategies qualityLimiterStrategy) {
            QualityLimiterFactory qualityLimiterFactory = new QualityLimiterFactory();
            object result = qualityLimiterFactory.CreateInstance(qualityLimiterStrategy);
            Assert.Equal(typeof(DefaultQualityLimiterStrategy), result.GetType());
        }
    }
}
