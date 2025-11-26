using ElderlySystem.DAL.Data;
using ElderlySystem.DAL.Model;
using Microsoft.EntityFrameworkCore;

namespace ElderlySystem.DAL.Repositories.Room
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _context;

        public RoomRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> CheckRoomNumberAsync(int RoomNumber)
        {
            return await _context.Rooms.AnyAsync(e=> e.RoomNumber == RoomNumber);
        }
        public async Task AddRoomAsync(DAL.Model.Room room)
        {
            await _context.AddAsync(room);
            await _context.SaveChangesAsync();
        }
    }
}
