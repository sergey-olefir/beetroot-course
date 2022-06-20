using Lesson23.Domain;

namespace Lesson23.Dependencies
{
    class Program
    {
        public static void Main()
        {
            var service = new RoomService();
            var rooms = service.GetAll();
        }
    }
}