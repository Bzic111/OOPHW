using System;
using System.Text;
using System.IO;

namespace OOPHomework
{
    public enum AccountType
    {
        Debit,
        Credit
    }

    class Program
    {
        static void Main(string[] args)
        {
            Architector archi = new();
            Builder bldr = new();
            int floors = 3;
            int entrances = 3;
            int apartmentsOnFloor = 3;

            Blueprint blprnt = new Blueprint(apartmentsOnFloor, floors, entrances, ApartmentType.Elite);
            blprnt.FloorHeight = 2.56;

            archi.AddBlueprint(blprnt);
            archi.CheckBlueprint(0);
            Building bld = bldr.CreateBuilding(archi.GetBlueprint(0));
            Console.WriteLine(archi.GetBlueprintInfo(0));
            Console.WriteLine(bldr.GetBuildingInfo(bld));
        }

        /// <summary>
        /// Методд раззворота строки.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        static string Reverse(string str)
        {
            StringBuilder sb = new StringBuilder(str.Length);
            for (int i = str.Length - 1; i >= 0; i--) sb.Append(str[i]);
            return sb.ToString();
        }
    }
}
