using System;
using Xunit;
using AsyncInn.Controllers;
using AsyncInn.Data;
using AsyncInn.Migrations;
using AsyncInn.Models;
using AsyncInn.Models.Interfaces;
using AsyncInn.Models.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace UnitTests_AsyncInn
{
    public class HotelsUnitTests
    {
        [Fact]
        public void CanGetNameOfHotel()
        {
            Hotel hotel = new Hotel();
            hotel.Name = "Downtown Seattle";

            Assert.Equal("Downtown Seattle", hotel.Name);
        }

        [Fact]
        public void CanSetNameOfHotel()
        {
            Hotel hotel = new Hotel();
            hotel.Name = "Downtown Seattle";
            hotel.Name = "Seattle";

            Assert.Equal("Seattle", hotel.Name);
        }

        [Fact]
        public void CanGetStreetAddressOfHotel()
        {
            Hotel hotel = new Hotel();
            hotel.StreetAddress = "123 1st Ave S";

            Assert.Equal("123 1st Ave S", hotel.StreetAddress);
        }

        [Fact]
        public void CanSetStreetAddressOfHotel()
        {
            Hotel hotel = new Hotel();
            hotel.StreetAddress = "123 1st Ave S";
            hotel.StreetAddress = "456 2nd Ave S";

            Assert.Equal("456 2nd Ave S", hotel.StreetAddress);
        }

        [Fact]
        public void CanGetCityOfHotel()
        {
            Hotel hotel = new Hotel();
            hotel.City = "Seattle";

            Assert.Equal("Seattle", hotel.City);
        }

        [Fact]
        public void CanSetCityOfHotel()
        {
            Hotel hotel = new Hotel();
            hotel.City = "Seattle";
            hotel.City = "Georgetown";

            Assert.Equal("Georgetown", hotel.City);
        }

        [Fact]
        public void CanGetStateOfHotel()
        {
            Hotel hotel = new Hotel();
            hotel.State = "WA";

            Assert.Equal("WA", hotel.State);
        }

        [Fact]
        public void CanSetStateOfHotel()
        {
            Hotel hotel = new Hotel();
            hotel.State = "WA";
            hotel.State = "OR";

            Assert.Equal("OR", hotel.State);
        }

        [Fact]
        public void CanGetZipCodeOfHotel()
        {
            Hotel hotel = new Hotel();
            hotel.ZipCode = "98101";

            Assert.Equal("98101", hotel.ZipCode);
        }

        [Fact]
        public void CanSetZipCodeOfHotel()
        {
            Hotel hotel = new Hotel();
            hotel.ZipCode = "98101";
            hotel.ZipCode = "98102";

            Assert.Equal("98102", hotel.ZipCode);
        }

        [Fact]
        public void CanGetFormattedAddress()
        {
            Hotel hotel = new Hotel();
            hotel.StreetAddress = "123 1st Ave S";
            hotel.City = "Seattle";
            hotel.State = "WA";
            hotel.ZipCode = "98101";

            Assert.Equal("123 1st Ave S, Seattle, WA 98101", hotel.FormattedAddress);
        }

        [Fact]
        public void CanGetPhoneNumberOfHotel()
        {
            Hotel hotel = new Hotel();
            hotel.Phone = "1234567890";

            Assert.Equal("1234567890", hotel.Phone);
        }

        [Fact]
        public void CanSetPhoneNumberOfHotel()
        {
            Hotel hotel = new Hotel();
            hotel.Phone = "1234567890";
            hotel.Phone = "2345678901";

            Assert.Equal("2345678901", hotel.Phone);
        }

        [Fact]
        public async void CanCreateHotel()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateHotel").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // Arrange
                Hotel hotel = new Hotel();
                hotel.ID = 1;
                hotel.Name = "Test Hotel";
                hotel.StreetAddress = "123 Test St";
                hotel.City = "Test City";
                hotel.State = "TS";
                hotel.ZipCode = "12345";
                hotel.Phone = "(123) 456-7890";

                // Act
                HotelManagementService hotelManagementService = new HotelManagementService(context);
                await hotelManagementService.CreateHotel(hotel);
                var result = context.Hotels.FirstOrDefault(h => h.ID == hotel.ID);

                // Assert
                Assert.Equal(hotel, result);
            }
        }

        [Fact]
        public async void CanDeleteHotel()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("DeleteHotel").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // Arrange
                Hotel hotel = new Hotel();
                hotel.ID = 1;
                hotel.Name = "Test Hotel";
                hotel.StreetAddress = "123 Test St";
                hotel.City = "Test City";
                hotel.State = "TS";
                hotel.ZipCode = "12345";
                hotel.Phone = "(123) 456-7890";

                // Act
                HotelManagementService hotelManagementService = new HotelManagementService(context);
                await hotelManagementService.CreateHotel(hotel);
                await hotelManagementService.DeleteHotel(hotel.ID);
                var result = context.Hotels.FirstOrDefault(h => h.ID == hotel.ID);

                // Assert
                Assert.Null(result);
            }
        }

        [Fact]
        public async void CanGetHotel()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("GetHotel").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // Arrange
                Hotel hotel = new Hotel();
                hotel.ID = 1;
                hotel.Name = "Test Hotel";
                hotel.StreetAddress = "123 Test St";
                hotel.City = "Test City";
                hotel.State = "TS";
                hotel.ZipCode = "12345";
                hotel.Phone = "(123) 456-7890";

                // Act
                HotelManagementService hotelManagementService = new HotelManagementService(context);
                await hotelManagementService.CreateHotel(hotel);
                var result = await hotelManagementService.GetHotel(hotel.ID);

                // Assert
                Assert.Equal(hotel, result);
            }
        }

        [Fact]
        public async void CanUpdateHotel()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("UpdateHotel").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // Arrange
                Hotel hotel = new Hotel();
                hotel.ID = 1;
                hotel.Name = "Test Hotel";
                hotel.StreetAddress = "123 Test St";
                hotel.City = "Test City";
                hotel.State = "TS";
                hotel.ZipCode = "12345";
                hotel.Phone = "(123) 456-7890";

                // Act
                HotelManagementService hotelManagementService = new HotelManagementService(context);
                await hotelManagementService.CreateHotel(hotel);
                hotel.City = "Testville";
                await hotelManagementService.UpdateHotel(hotel);
                var result = context.Hotels.FirstOrDefault(h => h.ID == hotel.ID);

                // Assert
                Assert.Equal(hotel, result);
            }
        }
    }

    public class RoomsUnitTests
    {
        [Fact]
        public void CanGetNameOfRoom()
        {
            Room room = new Room();
            room.Name = "Standard Studio";

            Assert.Equal("Standard Studio", room.Name);
        }

        [Fact]
        public void CanSetNameOfRoom()
        {
            Room room = new Room();
            room.Name = "Standard Studio";
            room.Name = "Studio";

            Assert.Equal("Studio", room.Name);
        }

        [Fact]
        public void CanGetLayoutOfRoom()
        {
            Room room = new Room();
            room.Layout = Layout.Studio;

            Assert.Equal(Layout.Studio, room.Layout);
        }

        [Fact]
        public void CanSetLayoutOfRoom()
        {
            Room room = new Room();
            room.Layout = Layout.Studio;
            room.Layout = Layout.TwoBedroom;

            Assert.Equal(Layout.TwoBedroom, room.Layout);
        }

        [Fact]
        public async void CanCreateRoom()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateRoom").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // Arrange
                Room room = new Room();
                room.ID = 1;
                room.Name = "Test Room";
                room.Layout = Layout.Studio;

                // Act
                RoomManagementService roomManagementService = new RoomManagementService(context);
                await roomManagementService.CreateRoom(room);
                var result = context.Rooms.FirstOrDefault(r => r.ID == room.ID);

                // Assert
                Assert.Equal(room, result);
            }
        }

        [Fact]
        public async void CanDeleteRoom()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("DeleteRoom").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // Arrange
                Room room = new Room();
                room.ID = 1;
                room.Name = "Test Room";
                room.Layout = Layout.Studio;

                // Act
                RoomManagementService roomManagementService = new RoomManagementService(context);
                await roomManagementService.CreateRoom(room);
                await roomManagementService.DeleteRoom(room.ID);
                var result = context.Rooms.FirstOrDefault(r => r.ID == room.ID);

                // Assert
                Assert.Null(result);
            }
        }

        [Fact]
        public async void CanGetRoom()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("GetRoom").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // Arrange
                Room room = new Room();
                room.ID = 1;
                room.Name = "Test Room";
                room.Layout = Layout.Studio;

                // Act
                RoomManagementService roomManagementService = new RoomManagementService(context);
                await roomManagementService.CreateRoom(room);
                var result = await roomManagementService.GetRoom(room.ID);

                // Assert
                Assert.Equal(room, result);
            }
        }

        [Fact]
        public async void CanUpdateRoom()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("UpdateRoom").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // Arrange
                Room room = new Room();
                room.ID = 1;
                room.Name = "Test Room";
                room.Layout = Layout.Studio;

                // Act
                RoomManagementService roomManagementService = new RoomManagementService(context);
                await roomManagementService.CreateRoom(room);
                room.Layout = Layout.OneBedroom;
                await roomManagementService.UpdateRoom(room);
                var result = context.Rooms.FirstOrDefault(r => r.ID == room.ID);

                // Assert
                Assert.Equal(room, result);
            }
        }
    }

    public class AmenitiesUnitTests
    {
        [Fact]
        public void CanGetNameOfAmenity()
        {
            Amenities amenities = new Amenities();
            amenities.Name = "Air Conditioning";

            Assert.Equal("Air Conditioning", amenities.Name);
        }

        [Fact]
        public void CanSetNameOfAmenity()
        {
            Amenities amenities = new Amenities();
            amenities.Name = "Air Conditioning";
            amenities.Name = "Heading/Cooling";

            Assert.Equal("Heading/Cooling", amenities.Name);
        }

        [Fact]
        public async void CanCreateAmenity()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("CreateAmenity").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // Arrange
                Amenities amenities = new Amenities();
                amenities.ID = 1;
                amenities.Name = "Test Amenity";

                // Act
                AmenityManagementService amenityManagementService = new AmenityManagementService(context);
                await amenityManagementService.CreateAmenity(amenities);
                var result = context.Amenities.FirstOrDefault(a => a.ID == amenities.ID);

                // Assert
                Assert.Equal(amenities, result);
            }
        }

        [Fact]
        public async void CanDeleteAmenity()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("DeleteAmenity").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // Arrange
                Amenities amenities = new Amenities();
                amenities.ID = 1;
                amenities.Name = "Test Amenity";

                // Act
                AmenityManagementService amenityManagementService = new AmenityManagementService(context);
                await amenityManagementService.CreateAmenity(amenities);
                await amenityManagementService.DeleteAmenity(amenities.ID);
                var result = context.Amenities.FirstOrDefault(a => a.ID == amenities.ID);

                // Assert
                Assert.Null(result);
            }
        }

        [Fact]
        public async void CanGetAmenity()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("GetAmenity").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // Arrange
                Amenities amenities = new Amenities();
                amenities.ID = 1;
                amenities.Name = "Test Amenity";

                // Act
                AmenityManagementService amenityManagementService = new AmenityManagementService(context);
                await amenityManagementService.CreateAmenity(amenities);
                var result = await amenityManagementService.GetAmenity(amenities.ID);

                // Assert
                Assert.Equal(amenities, result);
            }
        }

        [Fact]
        public async void CanUpdateAmenity()
        {
            DbContextOptions<AsyncInnDbContext> options = new DbContextOptionsBuilder<AsyncInnDbContext>().UseInMemoryDatabase("UpdateAmenity").Options;

            using (AsyncInnDbContext context = new AsyncInnDbContext(options))
            {
                // Arrange
                Amenities amenities = new Amenities();
                amenities.ID = 1;
                amenities.Name = "Test Amenity";

                // Act
                AmenityManagementService amenityManagementService = new AmenityManagementService(context);
                await amenityManagementService.CreateAmenity(amenities);
                amenities.Name = "Test Amenity 2";
                await amenityManagementService.UpdateAmenity(amenities);
                var result = context.Amenities.FirstOrDefault(a => a.ID == amenities.ID);

                // Assert
                Assert.Equal(amenities, result);
            }
        }
    }

    public class HotelRoomsUnitTests
    {
        [Fact]
        public void CanGetRoomHotelID()
        {
            HotelRoom hotelRoom = new HotelRoom();
            hotelRoom.HotelID = 1;

            Assert.True(hotelRoom.HotelID == 1);
        }

        [Fact]
        public void CanSetRoomHotelID()
        {
            HotelRoom hotelRoom = new HotelRoom();
            hotelRoom.HotelID = 1;
            hotelRoom.HotelID = 2;

            Assert.True(hotelRoom.HotelID == 2);
        }

        [Fact]
        public void CanGetRoomID()
        {
            HotelRoom hotelRoom = new HotelRoom();
            hotelRoom.RoomID = 1;

            Assert.True(hotelRoom.RoomID == 1);
        }

        [Fact]
        public void CanSetRoomID()
        {
            HotelRoom hotelRoom = new HotelRoom();
            hotelRoom.RoomID = 1;
            hotelRoom.RoomID = 2;

            Assert.True(hotelRoom.RoomID == 2);
        }

        [Fact]
        public void CanGetRoomNumber()
        {
            HotelRoom hotelRoom = new HotelRoom();
            hotelRoom.RoomNumber = 1;

            Assert.True(hotelRoom.RoomNumber == 1);
        }

        [Fact]
        public void CanSetRoomNumber()
        {
            HotelRoom hotelRoom = new HotelRoom();
            hotelRoom.RoomNumber = 1;
            hotelRoom.RoomNumber = 2;

            Assert.True(hotelRoom.RoomNumber == 2);
        }

        [Fact]
        public void CanGetRoomRate()
        {
            HotelRoom hotelRoom = new HotelRoom();
            hotelRoom.Rate = 100.00m;

            Assert.True(hotelRoom.Rate == 100.00m);
        }

        [Fact]
        public void CanSetRoomRate()
        {
            HotelRoom hotelRoom = new HotelRoom();
            hotelRoom.Rate = 100.00m;
            hotelRoom.Rate = 200.00m;

            Assert.True(hotelRoom.Rate == 200.00m);
        }

        [Fact]
        public void CanGetRoomPetFriendliness()
        {
            HotelRoom hotelRoom = new HotelRoom();
            hotelRoom.PetFriendly = true;

            Assert.True(hotelRoom.PetFriendly);
        }

        [Fact]
        public void CanSetRoomPetFriendliness()
        {
            HotelRoom hotelRoom = new HotelRoom();
            hotelRoom.PetFriendly = true;
            hotelRoom.PetFriendly = false;

            Assert.False(hotelRoom.PetFriendly);
        }
    }

    public class RoomAmenitiesUnitTests
    {
        [Fact]
        public void CanGetRoomAmenitiesAmenitiesID()
        {
            RoomAmenities roomAmenities = new RoomAmenities();
            roomAmenities.AmenitiesID = 1;

            Assert.True(roomAmenities.AmenitiesID == 1);
        }

        [Fact]
        public void CanSetRoomAmenitiesAmenitiesID()
        {
            RoomAmenities roomAmenities = new RoomAmenities();
            roomAmenities.AmenitiesID = 1;
            roomAmenities.AmenitiesID = 2;

            Assert.True(roomAmenities.AmenitiesID == 2);
        }

        [Fact]
        public void CanGetRoomAmenitiesRoomID()
        {
            RoomAmenities roomAmenities = new RoomAmenities();
            roomAmenities.RoomID = 1;

            Assert.True(roomAmenities.RoomID == 1);
        }

        [Fact]
        public void CanSetRoomAmenitiesRoomID()
        {
            RoomAmenities roomAmenities = new RoomAmenities();
            roomAmenities.RoomID = 1;
            roomAmenities.RoomID = 2;

            Assert.True(roomAmenities.RoomID == 2);
        }
    }
}
