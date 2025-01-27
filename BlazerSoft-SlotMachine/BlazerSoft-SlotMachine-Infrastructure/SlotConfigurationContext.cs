using BlazerSoft_SlotMachine.BlazerSoft_SlotMachine_Infrastructure.Interfaces;
using BlazerSoft_SlotMachine.Models;
using Microsoft.Extensions.Options;

namespace BlazerSoft_SlotMachine.BlazerSoft_SlotMachine_Infrastructure
{
    public class SlotConfigurationContext : IConfigurationContext
    {
        private readonly IMongoDatabase _db;
        public SlotConfigurationContext(IOptions<ConnectionSetting> options)
        {
            var client = new MongoClient(options.Value.ConnectionString);
            _db = client.GetDatabase(options.Value.Database);
        }
        public SlotConfiguration GetSlotConfiguration()
        {
            var result = slotConfiguration.Find<SlotConfiguration>(x => x.GetName() == "slotmachine-config");

            if (result == null)
            {
                return new SlotConfiguration(5, 3);
            }
            else
            {
                return result.First<SlotConfiguration>();
            }
        }
        public IMongoCollection<SlotConfiguration> slotConfiguration => _db.GetCollection<SlotConfiguration>("_configuration");
    }
}
