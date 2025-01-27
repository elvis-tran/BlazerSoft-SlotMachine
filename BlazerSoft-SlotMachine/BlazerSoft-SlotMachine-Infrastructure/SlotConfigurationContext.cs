using BlazerSoft_SlotMachine.BlazerSoft_SlotMachine_Infrastructure.Interfaces;
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
            var result = slotConfiguration.Find("{ name: slotmachine-config }");
        }
        public IMongoCollection<SlotConfiguration> slotConfiguration => _db.GetCollection<SlotConfiguration>("_configuration");
    }
}
