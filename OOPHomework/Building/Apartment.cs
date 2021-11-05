using System.Collections.Generic;
namespace OOPHomework
{
    partial class Building
    {
        class Apartment
        {
            public ApartmentType Type { get; private set; }
            private static int Counter = 1;
            public int _rooms { get; private set; }
            public double CurrentArea { get => GetCurrentArea(); }
            public List<Room> Rooms { get; private set; }

            private Apartment()
            {
                Rooms = new();
                Rooms.Add(new(9.0, RoomType.Kitchen));
                Rooms.Add(new(6.0, RoomType.Bathroom));
                Rooms.Add(new(4.0, RoomType.Toilet));
                Rooms.Add(new(5.0, RoomType.Hallway));
            }
            private Apartment(double area)
            {
                Rooms = new();
                Rooms.Add(new(area, RoomType.Other));
            }
            private Apartment(int rooms) : this()
            {
                _rooms = rooms;
                Rooms.Add(new(4.0, RoomType.Corridor));
                for (int i = 0; i < rooms; i++) Rooms.Add(new(Counter++, 12.0, RoomType.Other));

            }
            private Apartment(int rooms, int balcony) : this(rooms)
            {
                for (int i = 0; i <= balcony; i++) Rooms.Add(new(4.0, RoomType.Balcony));
            }
            private Apartment(int rooms, int balcony, int special, double area = 0.0) : this(rooms, balcony)
            {

                switch (special)
                {
                    case 4:
                        Rooms.Add(new(9, RoomType.Bedroom));
                        Rooms.Add(new(4.0, RoomType.Balcony));
                        Rooms.Add(new(Counter++, 12, RoomType.Hall));
                        Rooms.Add(new(Counter++, 12, RoomType.Dining));
                        goto case 3;
                    case 3:
                        Rooms.Add(new(6.0, RoomType.Bathroom));
                        Rooms.Add(new(4.0, RoomType.Toilet));
                        Rooms.Add(new(4.0, RoomType.Balcony));
                        goto case 2;
                    case 2:
                        Rooms.Add(new(Counter++, 12, RoomType.Bedroom));
                        Rooms.Add(new(Counter++, 12, RoomType.Childrens));
                        goto case 1;
                    case 1:
                        Rooms.Add(new(Counter++, 12, RoomType.Childrens));
                        Rooms.Add(new(Counter++, 12, RoomType.Bedroom));
                        Rooms.Add(new(Counter++, 12, RoomType.Office));
                        Rooms.Add(new(Counter++, 12, RoomType.Dining));
                        Rooms.Add(new(Counter++, 16, RoomType.Hall));
                        Rooms.Add(new(4.0, RoomType.Balcony));
                        break;
                    default:
                        if (special > 4)
                        {
                            for (int i = 0; i <= special - 4; i++) Rooms.Add(new Room(Counter++, 12, RoomType.Other));
                        }
                        else if (special < 1)
                        {
                            Rooms.Clear();
                            Rooms.Add(new Room(area, RoomType.Other));
                        }

                        goto case 4;
                }

            }
            private Apartment(Apartment apt, ApartmentType type) => apt.Type = type;
            public static Apartment Create(ApartmentType type, int rooms = 1, int balcony = 0, int special = 2, double area = 0.0)
            {
                switch (type)
                {
                    case ApartmentType.Usual: return new(new(1), type);
                    case ApartmentType.Improved: return new(new(rooms, balcony), type);
                    case ApartmentType.Special: return new(new(rooms, balcony, 1), type);
                    case ApartmentType.Elite: return new(new(rooms, balcony, special), type);
                    case ApartmentType.Basement: return new(new(area), type);
                    default: return null;
                }
            }
            private double GetCurrentArea()
            {
                double area = 0;
                foreach (var item in Rooms) area += item.Area;
                return area;
            }
        }
    }
}
