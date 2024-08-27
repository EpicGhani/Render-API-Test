using TestAPI.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace TestAPI.Services
{
    public class ItemsService
    {
        private readonly IMongoCollection<Item> _itemsCollection;

        public ItemsService(IOptions<ItemsDatabaseSettings> itemsDatabaseSettings)
        {
            var mongoClient = new MongoClient(itemsDatabaseSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(itemsDatabaseSettings.Value.DatabaseName);
            _itemsCollection = mongoDatabase.GetCollection<Item>(itemsDatabaseSettings.Value.ItemsCollectionName);
        }

        public async Task<List<Item>> GetAsync() => 
            await _itemsCollection.Find(i => true).ToListAsync();

        public async Task<Item?> GetAsync(string id) =>
            await _itemsCollection.Find(i => i.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Item newItem) =>
            await _itemsCollection.InsertOneAsync(newItem);

        public async Task UpdateAsync(string id, Item updatedItem) =>
            await _itemsCollection.ReplaceOneAsync(i => i.Id == id, updatedItem);

        public async Task RemoveAsync(string id) =>
            await _itemsCollection.DeleteOneAsync(i => i.Id == id);
    }
}
