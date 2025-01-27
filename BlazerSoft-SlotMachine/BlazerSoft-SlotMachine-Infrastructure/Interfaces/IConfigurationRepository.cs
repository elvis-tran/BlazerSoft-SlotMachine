using BlazerSoft_SlotMachine.Models;

namespace BlazerSoft_SlotMachine.BlazerSoft_SlotMachine_Infrastructure.Interfaces
{
    public interface IConfigurationRepository
    {
        public SlotConfiguration GetSlotConfiguration();
    }
}
