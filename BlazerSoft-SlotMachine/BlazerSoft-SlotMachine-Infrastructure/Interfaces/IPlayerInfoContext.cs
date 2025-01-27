using BlazerSoft_SlotMachine.Models;

namespace BlazerSoft_SlotMachine.BlazerSoft_SlotMachine_Infrastructure.Interfaces
{
    public interface IPlayerInfoContext
    {
        IMongoCollection<PlayerInfo> players { get; }
        public Task<PlayerInfo> GetPlayerInfoAsync(string playerName);
        public Task<bool> UpdatePlayerInfo(PlayerInfo playerInfo);
        public Task<PlayerInfo> Create(PlayerInfo playerInfo);
        public Task<bool> Delete(PlayerInfo playerInfo);

    }
}
