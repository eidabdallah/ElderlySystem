using ElderlySystem.DAL.Repositories.Room;

namespace ElderlySystem.BLL.Service.Room
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _repository;

        public RoomService(IRoomRepository Repository)
        {
            _repository = Repository;
        }

    }
}
