namespace BlazerSoft_SlotMachine.Models
{
    public class SlotConfiguration
    {
        private ObjectId _id;
        public int reelWidth;
        public int reelHeight;
        private string name;
        public SlotConfiguration() { }
        public SlotConfiguration(int reelWidth, int reelHeight)
        {
            this.reelWidth = reelWidth;
            this.reelHeight = reelHeight;
        }

        public string GetName()
        {
            return name;
        }
    }
}
