using GildedRoseKata.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace GildedRoseKata.Data {
    public class JsonDataSource : IDataSource {
        private const string DefaultItemsFilePath = "Data/items.json";

        private readonly string itemsFilePath;
        private bool isLoaded = false;

        private IEnumerable<IItemModel> items = null;
        public IEnumerable<IItemModel> Items {
            get {
                if(!this.isLoaded)
                    this.Load();
                return this.items;
            }
        }

        public JsonDataSource() {
            string workDir = AppDomain.CurrentDomain.BaseDirectory;
            string filePath = Path.Combine(workDir, JsonDataSource.DefaultItemsFilePath);
            this.itemsFilePath = filePath;
        }
        public JsonDataSource(string itemsFilePath) {
            this.itemsFilePath = itemsFilePath ?? throw new ArgumentNullException(nameof(itemsFilePath));
        }

        private void Load() {
            string itemsJson;
            try {
                itemsJson = File.ReadAllText(this.itemsFilePath);
            }
            catch(IOException e) {
                throw new IOException($"Could not read items json file at \"{this.itemsFilePath}\".", e);
            }
            ItemModel[] items = JsonConvert.DeserializeObject<ItemModel[]>(itemsJson);
            this.items = items;
            this.isLoaded = true;
        }
    }
}
