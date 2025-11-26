namespace ElderlySystem.DAL.Repositories.Room
{
    public interface IRoomRepository
    {
        Task<bool> CheckRoomNumberAsync(int RoomNumber);
        Task AddRoomAsync(DAL.Model.Room room);
    }
}
