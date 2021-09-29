using GildedRoseKata.Data;
using GildedRoseKata.Enums;
using GildedRoseKata.Models;
using System;
using System.IO;
using System.Linq;
using Xunit;

namespace GildedRoseTests.DataTests {
    public class JsonDataSourceTests {
        private JsonDataSource JsonDataSourceForFile(string filePath) {
            string workDir = AppDomain.CurrentDomain.BaseDirectory;
            string path = Path.Combine(workDir, filePath);
            return new JsonDataSource(path);
        }

        /// <summary>
        /// DADO    que o arquivo de items real exista
        /// QUANDO  a propriedade <see cref="JsonDataSource.Items"/> for acessada
        /// ENTÃO   o arquivo será carregado, disponibilizando seus nove itens para acesso.
        /// </summary>
        [Fact]
        public void ItemsGet_ValidarLeituraArquivoReal() {
            JsonDataSource dataSource = new JsonDataSource();
            Assert.Equal(9, dataSource.Items.Count());
        }

        /// <summary>
        /// DADO    que exista um arquivo json contendo dados dos items
        /// QUANDO  a propriedade <see cref="JsonDataSource.Items"/> for acessada
        /// ENTÃO   o arquivo deve ser carregado e armazenado em <see cref="JsonDataSource.Items"/>.
        /// </summary>
        [Fact]
        public void ItemsGet_ValidarLeituraDeItems() {
            JsonDataSource dataSource = this.JsonDataSourceForFile("DataTests/test-items-1.json");
            Assert.Equal(2, dataSource.Items.Count());
            // Test Item 1
            IItemModel item = dataSource.Items.First();
            Assert.Equal("test-item-1", item.Name);
            Assert.Equal(1, item.Quality);
            Assert.Equal(2, item.SellIn);
            Assert.Equal(QualityLimiterStrategies.Default, item.QualityLimiterStrategy);
            Assert.Equal(QualityUpdateStrategies.Noop, item.QualityUpdateStrategy);
            Assert.Equal(SellInUpdateStrategies.Decrease, item.SellInUpdateStrategy);
            // Test Item 2
            item = dataSource.Items.ElementAt(1);
            Assert.Equal("test-item-2", item.Name);
            Assert.Equal(100, item.Quality);
            Assert.Equal(200, item.SellIn);
            Assert.Equal(QualityLimiterStrategies.Legendary, item.QualityLimiterStrategy);
            Assert.Equal(QualityUpdateStrategies.Increase, item.QualityUpdateStrategy);
            Assert.Equal(SellInUpdateStrategies.Noop, item.SellInUpdateStrategy);
        }
    }
}
