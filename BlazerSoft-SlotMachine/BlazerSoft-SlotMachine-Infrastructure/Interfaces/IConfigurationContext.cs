using BlazerSoft_SlotMachine.Models;

namespace BlazerSoft_SlotMachine.BlazerSoft_SlotMachine_Infrastructure.Interfaces
{
    public interface IConfigurationContext
    {
        IMongoCollection<SlotConfiguration> slotConfiguration { get; }
        public SlotConfiguration GetSlotConfiguration();
    }
}
