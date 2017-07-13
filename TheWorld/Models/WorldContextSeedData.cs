using System.Linq;
using System.Threading.Tasks;

namespace TheWorld.Models
{
    public class WorldContextSeedData
    {
        private readonly WorldContext _context;

        public WorldContextSeedData(WorldContext context)
        {
            _context = context;
        }

        public async Task EnuserSeedData()
        {
            if (!_context.Trips.Any())
            {
                // TODO: Add seeding here
            }
        }
    }
}
