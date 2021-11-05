using System.Collections.Generic;

namespace OOPHomework
{
    partial class Building
    {
        class Floor
        {
            private static int Counter = 1;
            public int Number { get; private set; }
            public int ApartmentsCount { get => _apartments.Count; }
            public List<Apartment> _apartments { get; private set; }
            public double Height { get; private set; }
            private Floor()
            {
                Number = Counter++;
                _apartments = new List<Apartment>();
            }
            public Floor(int apartmentsOnFloor, ApartmentType type,double height = 0) : this()
            {
                Height = height;
                for (int i = 0; i < apartmentsOnFloor; i++) _apartments.Add(Apartment.Create(type));
            }
            public Floor(ApartmentType type, double area) : this()
            {
                _apartments.Add(Apartment.Create(ApartmentType.Basement, 1, 0, 0, area));
            }
        }
    }
}
