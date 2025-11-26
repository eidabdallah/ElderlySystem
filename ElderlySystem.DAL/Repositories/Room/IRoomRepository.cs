namespace ElderlySystem.DAL.Repositories.Room
{
    public interface IRoomRepository
    {
        Task<bool> CheckRoomNumberAsync(int RoomNumber);
        Task AddRoomAsync(DAL.Model.Room room);
        Task<DAL.Model.Room?> GetRoomByIdAsync(int id);
        Task<DAL.Model.Room?> GetRoomByIdWithImagesAsync(int id);
        Task<bool> UpdateRoomImagesAsync(DAL.Model.Room room, List<(string Url, string PublicId)> newImages);
        Task<bool> DeleteRoomAsync(DAL.Model.Room room);
        Task SaveChangesAsync();
    }
}
