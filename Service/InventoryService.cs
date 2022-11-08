using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Counter.Model;
using Newtonsoft.Json;

namespace Counter.Service
{
    public class InventoryService
    {
        public List<Item> LoadJson()
        {
            using (StreamReader r = new StreamReader(@"C:\Users\nali\source\repos\Counter\Counter\Data\inventory.json")) 
            {
                string json = r.ReadToEnd();
                var item = JsonConvert.DeserializeObject<List<Item>>(json); 
                return item;
            }
        }
    }
}
