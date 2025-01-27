using BlazerSoft_SlotMachine.BlazerSoft_SlotMachine_Infrastructure.Interfaces;
using BlazerSoft_SlotMachine.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BlazerSoft_SlotMachine.BlazerSoft_SlotMachine_Infrastructure
{
    public class PlayerInfoContext : IPlayerInfoContext
    {
        private readonly IMongoDatabase _db;
        
        //Add a logger
        public PlayerInfoContext(IOptions<ConnectionSetting> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }
        IMongoCollection<PlayerInfo> IPlayerInfoContext.players => _db.GetCollection<PlayerInfo>("_slotsPlayerInfo");

        public async Task<PlayerInfo> GetPlayerInfoAsync(string playerName)
        {
            var filter = Builders<PlayerInfo>.Filter.Eq("playerName", playerName);

            var collection = _db.GetCollection<PlayerInfo>("_slotsPlayerInfo");
            var result = await collection.Find(filter).FirstOrDefaultAsync();

            if(result != null)
            {
                return result;
            }
            else
            {
                return new PlayerInfo();
            }
        }

        public async Task<bool> UpdatePlayerInfo(PlayerInfo player)
        {
            var filter = Builders<PlayerInfo>.Filter.Eq(p => p.playerName, player.playerName);
            var update = Builders<PlayerInfo>.Update.Set(p => p.balance, player.balance);
            var collection = _db.GetCollection<PlayerInfo>("_slotsPlayerInfo");
            var result = await collection.UpdateOneAsync(filter, update);
            if(result.IsAcknowledged)
            {
                return true;
            }
            return false;
        }

        public Task<PlayerInfo> Create(PlayerInfo player)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(PlayerInfo player)
        {
            throw new NotImplementedException();
        }
    }
}
