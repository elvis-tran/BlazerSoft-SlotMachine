namespace BlazerSoft_SlotMachine.BlazerSoft_SlotMachine_Infrastructure
{
    public class SlotConfiguration
    {
        private ObjectId _id;
        private int reelWidth;
        private int reelHeight;
        private string name;
        public SlotConfiguration() { }
        public SlotConfiguration(int reelWidth, int reelHeight)
        {
            this.reelWidth = reelWidth;
            this.reelHeight = reelHeight;
        }
    }
}
