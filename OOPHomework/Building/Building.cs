using System;
using System.Collections.Generic;
using System.Text;

namespace OOPHomework
{
    partial class Building
    {
        private static int Counter = 0;

        public string Architector { get; private set; }
        public string Builder { get; private set; }

        private List<Entrance> _entrances { get; set; }
        private int _number { get; set; }
        private int _entranceCount { get => _entrances.Count; }
        private int _floorsCount { get => _entrances[0].FloorsCount; }
        private int _apartmentsCount { get => _entrances[0]._floors[0].ApartmentsCount * _floorsCount * _entranceCount; }
        private double _fullHeight { get => _entrances[0]._floors[0].Height * _entrances[0]._floors.Count + _entrances[0]._floors.Count*_ceiling; }
        private double _ceiling { get; set; } = 0.40;
        private Floor _basement { get; set; } = null;

        private Building()
        {
            _number = ++Counter;
            _entrances = new();
        }
        public Building(int entrances, int floors, int apartmentsOnFloor, ApartmentType type, double floorHeight) : this()
        {
            for (int i = 0; i < entrances; i++) _entrances.Add(new Entrance(floors, apartmentsOnFloor, type, floorHeight));
        }
        public Building SetInfo(Blueprint bp,Builder bldr)
        {
            Architector = bp.Architector;
            Builder = bldr.Name;
            return this;
        }

        public void AddBasement()
        {
            _basement = new Floor(1, ApartmentType.Basement);
        }

        public void SetCounter(int value) => Counter = value;
        public void DropCounter() => Counter = 0;

        public string GetBuildingNumber() => $"{_number}";
        public string GetApartmentCount() => $"{_apartmentsCount}";
        public string GetApartmentsOnFloor() => $"{_entrances[0]._floors[0].ApartmentsCount}";
        public string GetApartmentsCount() => $"{_apartmentsCount}";
        public string GetApartmentsType() => $"{_entrances[0]._floors[0]._apartments[0].Type}";
        public string GetFloorHeight() => $"{_entrances[0]._floors[0].Height}";
        public string GetFullHeight() => $"{Math.Round(_fullHeight, 2)}";
        public string GetEntranceCount() => $"{_entranceCount}";
        public string GetFloorsCount() => $"{_floorsCount}";
        public string GetBaseInfo() => _basement != null ? $"Цокольный этаж : есть\n" : $"Цокольный этаж : нет\n";
    }
}
