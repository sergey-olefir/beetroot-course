using Lesson23.Contracts;

namespace Lesson23.DataAccess
{
    public interface IDataAccess
    {
        List<Room> GetAll();
        void WriteAll(List<Room> rooms);
    }

    public class FileDataAccess : IDataAccess
    {
        private string filePath = "rooms.file";

        public List<Room> GetAll()
        {
            using (Stream stream = File.Open(this.filePath, FileMode.Open))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                return (List<Room>)binaryFormatter.Deserialize(stream);
            }
        }

        public void WriteAll(List<Room> rooms)
        {
            using (Stream stream = File.Open(this.filePath, FileMode.Append))
            {
                var binaryFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                binaryFormatter.Serialize(stream, rooms);
            }
        }
    }
}