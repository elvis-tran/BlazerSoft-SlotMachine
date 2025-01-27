using BlazerSoft_SlotMachine.BlazerSoft_SlotMachine_Infrastructure.Interfaces;
using BlazerSoft_SlotMachine.Models;
using BlazerSoft_SlotMachine_Infrastructure;

namespace BlazerSoft_SlotMachine.BlazerSoft_SlotMachine_Infrastructure
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly IConfigurationContext _configurationContext;
        ConfigurationRepository(IConfigurationContext configurationContext)
        {
            _configurationContext = configurationContext;
        }

        public SlotConfiguration GetSlotConfiguration()
        {
            return _configurationContext.GetSlotConfiguration();
        }
    }
}
