using FluentAssertions;
using Lesson23.Contracts;
using Lesson23.DataAccess;
using Lesson23.Domain;
using Moq;
using NUnit.Framework;

namespace Lesson23.UnitTests.Domain
{
    public class RoomServiceTests
    {
        [Test(Description = "Коли дата співпадає, має бути труе")]
        public void IsBooked_WhenTimeIsCorrect_ReturnsTrue()
        {
            //Arrange
            //SUT - System Under Testing
            var roomService = new RoomService(null);
            var time = new DateTime(2001, 01, 01);
            var room = new Room
            {
                Meetings = new List<Meeting>
                {
                    new Meeting
                    {
                        Date = time
                    },
                    new Meeting
                    {
                        Date = DateTime.Now
                    }
                }
            };

            //Act
            var result = roomService.IsBooked(room, time);

            //Assert
            result.Should().BeTrue();
        }

        [Test]
        public void GetAll_Always_ReturnsData()
        {
            //Arrange
            var room = new Room
            {
                Meetings = new List<Meeting>
                {
                    new Meeting
                    {
                        Date = DateTime.Today
                    },
                    new Meeting
                    {
                        Date = DateTime.Now
                    }
                }
            };
            var rooms = new List<Room> { room };
            var fakeDataAccess = new FakeDataAccess(rooms);

            //System Under Testing
            var roomService = new RoomService(fakeDataAccess);

            //Act
            var actualRooms = roomService.GetAll();

            //Assert
            actualRooms.Should().BeEquivalentTo(rooms);
        }

        [Test]
        public void GetAll_Always_ReturnsDataWithMoq()
        {
            //Arrange
            var room = new Room
            {
                Meetings = new List<Meeting>
                {
                    new Meeting
                    {
                        Date = DateTime.Today
                    },
                    new Meeting
                    {
                        Date = DateTime.Now
                    }
                }
            };
            var rooms = new List<Room> { room };
            var mock = new Mock<IDataAccess>();
            mock.Setup(x => x.GetAll()).Returns(rooms);

            //System Under Testing
            var roomService = new RoomService(mock.Object);

            //Act
            var actualRooms = roomService.GetAll();

            //Assert
            actualRooms.Should().BeEquivalentTo(rooms);
        }

        [Test]
        public void WriteAll_Always_WritesData()
        {
            var fakeDataAccess = new FakeDataAccess(new List<Room>());
            var roomService = new RoomService(fakeDataAccess);

            roomService.WriteAll(new List<Room>());

            fakeDataAccess.WriteAllInvokations.Should().Be(1);
        }

        [Test]
        public void WriteAll_Always_WritesDataWithMoq()
        {
            var mock = new Mock<IDataAccess>();
            var roomService = new RoomService(mock.Object);

            roomService.WriteAll(new List<Room>());

            mock.Verify(x => x.WriteAll(It.IsAny<List<Room>>()), Times.Once);
        }

        class FakeDataAccess : IDataAccess
        {
            private readonly List<Room> _rooms;
            public int WriteAllInvokations { get; private set; }

            public FakeDataAccess(List<Room> rooms)
            {
                this._rooms = rooms;
            }

            public List<Room> GetAll()
                => this._rooms;

            public void WriteAll(List<Room> rooms)
            {
                this.WriteAllInvokations++;
            }
        }
    }
}