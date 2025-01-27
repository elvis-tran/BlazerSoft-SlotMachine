namespace BlazerSoft_SlotMachine.Models
{
    public class PlayerInfo
    {
        private ObjectId _id;
        public string playerId { get; set; }
        public int balance { get; set; }
        public string playerName { get; set; }

        public PlayerInfo() { }
        public PlayerInfo(string playerId, int balance)
        {
            this.playerId = playerId;
            this.balance = balance;
            this.playerName = "";
        }
        public PlayerInfo(string playerId, int balance, string playerName)
        {
            this.playerId = playerId;
            this.balance = balance;
            this.playerName = playerName;
        }
        public int GetBalance()
        {
            return this.balance;
        }

        public string GetPlayerName()
        {
            return this.playerName;
        }

        //Can be positive or negative
        public void UpdateBalance(int updateAmount)
        {
            this.balance += updateAmount;
        }
    }
}
