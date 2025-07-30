using UnityEngine;
using LitJson;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Arcadia.UI.Inventory4
{
    public class ItemDataBase : MonoBehaviour
    {
        private List<Item> _items = new List<Item>();
        private JsonData _jsonData;

        private void Start()
        {
            Item item = new Item(0, "Bronze", 6);
            _items.Add(item);
            Debug.Log(_items[0].Title);
            _jsonData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
        }

        private void ConstructItemDatabase()
        {
            
        }
    }

    public class Item
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Value { get; set; }

        public Item(int id, string title, int value)
        {
            this.ID = id;
            this.Title = title;
            this.Value = value;
        }
    }
}