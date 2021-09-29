using GildedRoseKata.Data;
using GildedRoseKata.Models;
using GildedRoseKata.Services;
using System.Collections.Generic;
using System.Linq;

namespace GildedRoseKata {
    public class GildedRose {
        private readonly IDataSource dataSource;
        private readonly IItemDataFactory itemDataFactory;

        /// <summary>
        /// ATENÇÃO: Pertence ao Goblin!
        /// (Não alterar)
        /// </summary>
        IList<Item> Items;

        /// <summary>
        /// Assim que o Goblin sair de perto, remover esta propriedade e alterar o tipo de
        /// <see cref="GildedRose.Items"/> para <see cref="IReadOnlyList{T}"/> de <see cref="Item"/>.
        /// </summary>
        public IReadOnlyDictionary<Item, IItemData> ItemDatas { get; private set; }

        public GildedRose(IDataSource dataSource, IItemDataFactory itemFactory) {
            this.dataSource = dataSource ?? throw new System.ArgumentNullException(nameof(dataSource));
            this.itemDataFactory = itemFactory ?? throw new System.ArgumentNullException(nameof(itemFactory));
            this.Setup();
        }

        private void Setup() {
            this.ItemDatas = this.dataSource.Items
                .Select(model => this.itemDataFactory.CreateFrom(model))
                .ToDictionary(itemData => itemData.Item);
            this.Items = this.ItemDatas.Keys
                .ToList()
                .AsReadOnly();
        }

        /// <summary>
        /// Efetua as operações de passagem de dia, sendo elas:<br/>
        /// 1. Atualiza a qualidade dos itens;<br/>
        /// 2. Atualiza o prazo de venda dos itens;<br/>
        /// 3. Atualiza a qualidade dos itens após a alteração da data;<br/>
        /// 4. Garante que a qualidade está dentro dos limites.<br/>
        /// </summary>
        public void UpdateQuality() {
            IItemData itemData;
            foreach(Item item in this.Items) {
                // Para não deixar this.Items sem uso, vou associar
                // Item a IItemData a partir de um dicionario
                itemData = this.ItemDatas[item];
                itemData.QualityUpdateStrategy.UpdateQuality(item);
                itemData.SellInUpdateStrategy.UpdateSellIn(item);
                itemData.LateQualityUpdateStrategy.LateUpdateQuality(item);
                item.Quality = itemData.QualityLimiterStrategy.Limit(item.Quality);
            }
        }
    }
}
