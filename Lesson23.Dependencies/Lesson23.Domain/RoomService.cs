using Lesson23.Contracts;
using Lesson23.DataAccess;

namespace Lesson23.Domain
{
    public class RoomService
    {
        private readonly FileDataAccess _fileDataAccess;

        public RoomService()
        {
            this._fileDataAccess = new FileDataAccess();
        }

        public List<Room> GetAll()
        {
            return this._fileDataAccess.GetAll();
        }

        public void WriteAll(List<Room> rooms)
        {
            this._fileDataAccess.WriteAll(rooms);
        }
    }
}