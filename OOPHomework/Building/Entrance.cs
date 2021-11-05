using System.Collections.Generic;

namespace OOPHomework
{
    partial class Building
    {
        class Entrance
        {
            private static int _counter = 1;
            public int Number;
            public int FloorsCount { get => _floors.Count; }
            internal List<Floor> _floors;
            private Entrance()
            {
                Number = _counter++;
                _floors = new();
            }
            public Entrance(int floorsCount, int apartmentsOnFloor, ApartmentType type, double floorHeight = 0) : this()
            {
                for (int i = 0; i < floorsCount; i++) _floors.Add(new Floor(apartmentsOnFloor, type, floorHeight));
            }
        }
    }
}
