using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPHomework
{
    class Architector
    {
        public string Name = "Archibald";
        private List<Blueprint> Blueprints;
        public Architector() => Blueprints = new();
        public void AddBlueprint(Blueprint blueprint) => Blueprints.Add(blueprint.SetName(Name));
        public Status CheckBlueprint(int counter) => counter < Blueprints.Count ? CheckBlueprint(Blueprints[counter]) : Status.Error;
        public Status CheckBlueprint(Blueprint blueprint)
        {
            int apts = blueprint.ApartmentsOnFloor;
            int flrs = blueprint.Floors;
            int ents = blueprint.Entrances;
            Status state = (apts * flrs) % ents == 0 ? Status.Ready : Status.Error;
            if (blueprint.FloorHeight < 2.0) state = Status.Error;
            blueprint.SetStatus(state);
            return state;
        }
        public Blueprint GetBlueprint(int counter) => counter < Blueprints.Count ? Blueprints[counter] : null;
        public string GetBlueprintInfo(int counter)
        {
            StringBuilder sb = new();

            sb.AppendLine($"Проект номер: {counter}");
            sb.AppendLine($"Архитектор: {Blueprints[counter].Architector}");
            sb.AppendLine($"Тип апартаментов: {Blueprints[counter].Type}");
            sb.AppendLine($"Всего Квартир: {Blueprints[counter].ApartmentsOnFloor * Blueprints[counter].Floors * Blueprints[counter].Entrances}\n");
            sb.AppendLine($"на: {Blueprints[counter].Floors} этажей ");
            sb.AppendLine($"в: {Blueprints[counter].Entrances} подъездах: ");

            if (Blueprints[counter].Basement) sb.AppendLine($"Цокольный этаж: есть");
            else sb.AppendLine($"Цокольный этаж: отсутствует");

            return sb.ToString();
        }
        public void SetFloorHeight(int counter, double h) => SetFloorHeight(Blueprints[counter], h);
        public void SetFloorHeight(Blueprint bp, double h) => bp.FloorHeight = h;
    }
}
