using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace OOPHomework
{
    class Builder
    {
        public string Name = "Bob";
        private List<Blueprint> Blueprints;
        public Builder() => Blueprints = new();

        private void AddBlueprint(Blueprint blueprint) => Blueprints.Add(blueprint);
        public List<Blueprint> GetAllBlueprints() => Blueprints;
        public Blueprint GetBlueprint(int counter)
        {
            if (counter >= 0 && counter < Blueprints.Count && Blueprints.Count > 0) return Blueprints[counter];
            else return null;
        }
        public Building CreateBuilding(Blueprint blueprint)
        {
            int entr = blueprint.Entrances;
            int floors = blueprint.Floors;
            int aprtsOnFl = blueprint.ApartmentsOnFloor;
            if (blueprint.Status == Status.Ready)
            {
                AddBlueprint(blueprint);
                Building bld = new(entr, floors, aprtsOnFl, blueprint.Type,blueprint.FloorHeight);
                if (blueprint.Basement) bld.AddBasement();
                
                return bld.SetInfo(blueprint, this);
            }
            else return null;
        }
        public Building CreateBuilding(int counter)
        {
            if (counter >= 0 && counter < Blueprints.Count && Blueprints.Count > 0) return CreateBuilding(Blueprints[counter]);
            else return null;
        }
        public string GetBuildingInfo(Building bld)
        {
            StringBuilder sb = new();
            sb.AppendLine($"Архитектор : {bld.Architector}");
            sb.AppendLine($"Строитель : {bld.Builder}");
            sb.AppendLine($"Этажей : {bld.GetFloorsCount()}");
            sb.AppendLine($"Всего квартир : {bld.GetApartmentCount()}");
            sb.AppendLine($"Квартир на этаже : {bld.GetApartmentsOnFloor()}");
            sb.AppendLine($"Всего Подъездов : {bld.GetEntranceCount()}");
            sb.AppendLine($"Квартир в подъезде : {bld.GetApartmentsCount()}");
            sb.AppendLine($"Тип квартир : {bld.GetApartmentsType()}");
            sb.AppendLine($"Высота этажа : {bld.GetFloorHeight()}");
            sb.AppendLine($"Общая высота здания : {bld.GetFullHeight()}");
            sb.Append(bld.GetBaseInfo());
            return sb.ToString();
        }
    }
}
