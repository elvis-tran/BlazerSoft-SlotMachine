using BlazerSoft_SlotMachine.Models;

namespace BlazerSoft_SlotMachine_Infrastructure
{
    public interface IPlayerInfoRepository
    {
        public Task<IEnumerable<PlayerInfo>> GetAll();
        public Task<PlayerInfo> Create(PlayerInfo playerInfo);
        public Task<bool> Delete(PlayerInfo playerInfo);
        public Task<bool> UpdatePlayer(PlayerInfo playerInfo);
        public Task<PlayerInfo> GetPlayer(string playerName);
        public Task<bool> EnoughFunds(string playerName, int amountBet);
        public int GetBalance(string playerName);
    }
}
