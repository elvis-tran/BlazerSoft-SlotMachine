namespace BlazerSoft_SlotMachine.Models
{
    public class PlayerInfo
    {
        private ObjectId _id;
        private string playerId { get; set; }
        private double balance { get; set; }
        private string playerName { get; set; }

        public PlayerInfo() { }
        public PlayerInfo(string playerId, double balance)
        {
            this.playerId = playerId;
            this.balance = balance;
        }

        public string GetPlayerId()
        {
            return this.playerId;
        }

        public double GetBalance()
        {
            return this.balance;
        }

        public string GetPlayerName()
        {
            return this.playerName;
        }

        //Can be positive or negative
        public void UpdateBalance(double updateAmount)
        {
            this.balance += updateAmount;
        }
    }
}
