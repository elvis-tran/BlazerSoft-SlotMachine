using BlazerSoft_SlotMachine.BlazerSoft_SlotMachine_Infrastructure.Interfaces;
using BlazerSoft_SlotMachine.Models;
using Microsoft.Extensions.Options;

namespace BlazerSoft_SlotMachine.BlazerSoft_SlotMachine_Infrastructure
{
    public class PlayerInfoContext : IPlayerInfoContext
    {
        private readonly IMongoDatabase _db;
        
        public PlayerInfoContext(IOptions<ConnectionSetting> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }
        IMongoCollection<PlayerInfo> IPlayerInfoContext.players => _db.GetCollection<PlayerInfo>("_slotsPlayerInfo");

        public Task<PlayerInfo> GetPlayerInfoAsync(string playerName)
        {
            var collection = _db.GetCollection<PlayerInfo>("_slotsPlayerInfo");
            var result = collection.FindAsync("playername");
            
            //Use the result found for the player, if none then return null
            return null;
        }

        public Task<bool> UpdatePlayerInfo(PlayerInfo playerInfo)
        {
            throw new NotImplementedException();
        }

        public Task<PlayerInfo> Create(PlayerInfo playerInfo)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(PlayerInfo playerInfo)
        {
            throw new NotImplementedException();
        }
    }
}
