using GildedRoseKata.Models;
using System;

namespace GildedRoseKata.Services {
    public class ItemDataFactory : IItemDataFactory {
        private readonly ILateQualityUpdateFactory lateQualityUpdateFactory;
        private readonly IQualityLimiterFactory qualityLimiterFactory;
        private readonly IQualityUpdateFactory qualityUpdateFactory;
        private readonly ISellInUpdateFactory sellInUpdateFactory;

        public ItemDataFactory(
            ILateQualityUpdateFactory lateQualityUpdateFactory,
            IQualityLimiterFactory qualityLimiterFactory,
            IQualityUpdateFactory qualityUpdateFactory,
            ISellInUpdateFactory sellInUpdateFactory
        ) {
            this.lateQualityUpdateFactory = lateQualityUpdateFactory ?? throw new ArgumentNullException(nameof(lateQualityUpdateFactory));
            this.qualityLimiterFactory = qualityLimiterFactory ?? throw new ArgumentNullException(nameof(qualityLimiterFactory));
            this.qualityUpdateFactory = qualityUpdateFactory ?? throw new ArgumentNullException(nameof(qualityUpdateFactory));
            this.sellInUpdateFactory = sellInUpdateFactory ?? throw new ArgumentNullException(nameof(sellInUpdateFactory));
        }

        public IItemData CreateFrom(IItemModel itemModel) {
            if(itemModel is null)
                throw new ArgumentNullException(nameof(itemModel));
            return new ItemData() {
                Item = new Item() {
                    Name = itemModel.Name,
                    Quality = itemModel.Quality,
                    SellIn = itemModel.SellIn
                },
                LateQualityUpdateStrategy = this.lateQualityUpdateFactory.CreateInstance(itemModel.QualityUpdateStrategy),
                QualityLimiterStrategy = this.qualityLimiterFactory.CreateInstance(itemModel.QualityLimiterStrategy),
                QualityUpdateStrategy = this.qualityUpdateFactory.CreateInstance(itemModel.QualityUpdateStrategy),
                SellInUpdateStrategy = this.sellInUpdateFactory.CreateInstance(itemModel.SellInUpdateStrategy)
            };
        }
    }
}
