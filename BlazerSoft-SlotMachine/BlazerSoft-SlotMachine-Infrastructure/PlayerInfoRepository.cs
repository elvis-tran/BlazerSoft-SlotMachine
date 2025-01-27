namespace BlazerSoft_SlotMachine_Infrastructure
{
    using BlazerSoft_SlotMachine.BlazerSoft_SlotMachine_Infrastructure.Interfaces;
    using BlazerSoft_SlotMachine.Models;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PlayerInfoRepository : IPlayerInfoRepository
    {
        private readonly IPlayerInfoContext _playerInfoContext;
        PlayerInfoRepository(IPlayerInfoContext playerInfoContext)
        {
            _playerInfoContext = playerInfoContext;
        }
        public async Task<PlayerInfo> Create(PlayerInfo playerInfo)
        {
            return await _playerInfoContext.Create(playerInfo);
        }

        public Task<bool> Delete(PlayerInfo playerInfo)
        {
            return _playerInfoContext.Delete(playerInfo);   
        }
        
        public Task<IEnumerable<PlayerInfo>> GetAll()
        {
            return (Task<IEnumerable<PlayerInfo>>)_playerInfoContext.players;
        }

        public async Task<PlayerInfo> GetPlayer(string playerName)
        {
            return await _playerInfoContext.GetPlayerInfoAsync(playerName);
        }

        public async Task<bool> UpdatePlayer(PlayerInfo playerInfo)
        {
            return await _playerInfoContext.UpdatePlayerInfo(playerInfo);
        }
    }
}
