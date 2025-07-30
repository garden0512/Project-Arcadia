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
        private JsonData _itemData;

        private void Start()
        {
            _itemData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
            ConstructItemDatabase();
            Debug.Log(FetchItemById(0).Description);
        }

        private void ConstructItemDatabase()
        {
            for (int i = 0; i < _itemData.Count; i++)
            {
                _items.Add(new Item((int)_itemData[i]["id"],
                    _itemData[i]["title"].ToString(),
                    (int)_itemData[i]["value"],
                    (int)_itemData[i]["stats"]["power"],
                    (int)_itemData[i]["stats"]["defence"],
                    (int)_itemData[i]["stats"]["vitality"],
                    _itemData[i]["description"].ToString(),
                    (bool)_itemData[i]["stackable"],
                    (int)_itemData[i]["rarity"],
                    _itemData[i]["slug"].ToString()));
            }
        }

        public Item FetchItemById(int id)
        {
            for (int i = 0; i < _items.Count; i++)
            {
                if (_items[i].ID == id)
                {
                    return _items[i];
                }
            }
            return null;
        }
    }

    public class Item
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Value { get; set; }
        public int Power{get;set;}
        public int Defence{get;set;}
        public int Vitality{get;set;}
        public string Description{get;set;}
        public bool Stackable{get;set;}
        public int Rarity{get;set;}
        public string Slug{get;set;}
        public Sprite Sprite{get;set;}

        public Item(int id, string title, int value, int power, int defence, int vitality, string description, bool stackable, int rarity, string slug)
        {
            this.ID = id;
            this.Title = title;
            this.Value = value;
            this.Power = power;
            this.Defence = defence;
            this.Vitality = vitality;
            this.Description = description;
            this.Stackable = stackable;
            this.Rarity = rarity;
            this.Slug = slug;
            this.Sprite = Resources.Load<Sprite>("Temps/TestUI/" + this.Slug);
        }

        public Item(int id, string title, int value)
        {
            this.ID = id;
            this.Title = title;
            this.Value = value;
        }
        public Item()
        {
            this.ID = -1;
        }
    }
}