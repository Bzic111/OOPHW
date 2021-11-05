namespace OOPHomework
{
    partial class Building
    {
        class Room
        {
            public RoomType Type { get; private set; }
            public int Number { get; private set; }
            public double Area { get; private set; }

            private Room() { }
            private Room(RoomType type) : this() => Type = type;
            public Room(double area, RoomType type) : this(type) => Area = area;
            public Room(int num, double area, RoomType type) : this(area, type) => Number = num;
        }
    }
}
