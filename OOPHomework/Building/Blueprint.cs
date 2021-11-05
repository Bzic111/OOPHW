namespace OOPHomework
{
    class Blueprint
    {
        public string Architector { get; private set; }
        public int ApartmentsOnFloor { get; private set; }
        public int Floors { get; private set; }
        public int Entrances { get; private set; }
        public Status Status { get; private set; }

        public double FloorHeight { get; set; }
        public double MaxBuildingHeight { get; set; }
        public ApartmentType Type { get; set; }
        public bool Basement { get; set; }

        public Blueprint(int apartmentsOnFloor, int floors, int entrances, ApartmentType type, bool basement = false)
        {
            ApartmentsOnFloor = apartmentsOnFloor;
            Type = type;
            Floors = floors;
            Entrances = entrances;
            Status = Status.inProgress;
            Basement = basement;
        }
        public void SetStatus(Status state) => Status = state;
        public Blueprint SetName(string name)
        {
            Architector = name;
            return this;
        }
    }
}
