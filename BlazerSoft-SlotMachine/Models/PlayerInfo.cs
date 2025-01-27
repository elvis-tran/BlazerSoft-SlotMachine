namespace BlazerSoft_SlotMachine.Models
{
    public class PlayerInfo
    {
        private string playerId { get; set; }
        private double balance { get; set; }

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

        //Can be positive or negative
        public void UpdateBalance(double updateAmount)
        {
            this.balance += updateAmount;
        }
    }
}
