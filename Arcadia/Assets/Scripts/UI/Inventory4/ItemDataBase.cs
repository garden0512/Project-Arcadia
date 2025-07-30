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
            _jsonData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Items.json"));
        }
    }

    public class Item
    {
        
    }
}