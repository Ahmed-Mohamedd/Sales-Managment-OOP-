using Newtonsoft.Json;
using Sales_Managment.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales_Managment.DAL.DataStore
{
    public static class DataStore<Entity>
    {

        private static string DataPath = Path.Combine("E:\\1-(EraaSoft)\\OOP\\Sales Managment\\Sales Managment.DAL\\DataStore", $"{typeof(Entity).ToString().Split(".")[3]}Data.json");
        public static List<Entity> LoadData()
        {
            List<Entity> listOfCustomers = new List<Entity>();

            if (File.Exists(DataPath))
            {
                string json = File.ReadAllText(DataPath);
                if (!string.IsNullOrWhiteSpace(json))
                {
                    listOfCustomers = JsonConvert.DeserializeObject<List<Entity>>(json);
                }
            };

            return listOfCustomers;
        }

        public static void Save(List<Entity> productsToSave)
        {
            if (!File.Exists(DataPath))
                File.Create(DataPath);

            string json = JsonConvert.SerializeObject(productsToSave);

            File.WriteAllText(DataPath, json);
        }
    }
}
