using System.Collections.Generic;

namespace GildedRoseKata {
    public class GildedRose {
        /// <summary>
        /// ATENÇÃO: Pertence ao Goblin!
        /// (Não alterar)
        /// </summary>
        IList<Item> Items;

        public GildedRose(IList<Item> Items) {
            this.Items = Items;
        }

        public void UpdateQuality() {
            for(var i = 0; i < this.Items.Count; i++) {
                if(this.Items[i].Name != "Aged Brie" && this.Items[i].Name != "Backstage passes to a TAFKAL80ETC concert") {
                    if(this.Items[i].Quality > 0) {
                        if(this.Items[i].Name != "Sulfuras, Hand of Ragnaros") {
                            this.Items[i].Quality = this.Items[i].Quality - 1;
                        }
                    }
                }
                else {
                    if(this.Items[i].Quality < 50) {
                        this.Items[i].Quality = this.Items[i].Quality + 1;

                        if(this.Items[i].Name == "Backstage passes to a TAFKAL80ETC concert") {
                            if(this.Items[i].SellIn < 11) {
                                if(this.Items[i].Quality < 50) {
                                    this.Items[i].Quality = this.Items[i].Quality + 1;
                                }
                            }

                            if(this.Items[i].SellIn < 6) {
                                if(this.Items[i].Quality < 50) {
                                    this.Items[i].Quality = this.Items[i].Quality + 1;
                                }
                            }
                        }
                    }
                }

                if(this.Items[i].Name != "Sulfuras, Hand of Ragnaros") {
                    this.Items[i].SellIn = this.Items[i].SellIn - 1;
                }

                if(this.Items[i].SellIn < 0) {
                    if(this.Items[i].Name != "Aged Brie") {
                        if(this.Items[i].Name != "Backstage passes to a TAFKAL80ETC concert") {
                            if(this.Items[i].Quality > 0) {
                                if(this.Items[i].Name != "Sulfuras, Hand of Ragnaros") {
                                    this.Items[i].Quality = this.Items[i].Quality - 1;
                                }
                            }
                        }
                        else {
                            this.Items[i].Quality = this.Items[i].Quality - this.Items[i].Quality;
                        }
                    }
                    else {
                        if(this.Items[i].Quality < 50) {
                            this.Items[i].Quality = this.Items[i].Quality + 1;
                        }
                    }
                }
            }
        }
    }
}
