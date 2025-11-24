using ElderlySystem.DAL.Data;

namespace ElderlySystem.DAL.Repositories.Room
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _context;

        public RoomRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}
