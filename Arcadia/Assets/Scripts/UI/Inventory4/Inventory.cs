using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace Arcadia.UI.Inventory4
{
    public class Inventory : MonoBehaviour
    {
        private GameObject _inventoryPanel;
        private GameObject _slotPanel;
        private ItemDataBase _itemDataBase;
        private int _slotAmount;
        public GameObject _inventorySlot;
        public GameObject _inventoryItem;
        public List<Item> items = new List<Item>();
        public List<GameObject> slots = new List<GameObject>();

        private void Start()
        {
            _itemDataBase = GetComponent<ItemDataBase>();
            _slotAmount = 40;
            _inventoryPanel = GameObject.Find("InventoryPanel");
            _slotPanel = _inventoryPanel.transform.Find("SlotPanel").gameObject; //FindChild 경고 있음
            for (int i = 0; i < _slotAmount; i++)
            {
                items.Add(new Item());
                slots.Add(Instantiate(_inventorySlot));
                slots[i].GetComponent <Slot>().id = i;
                slots[i].transform.SetParent(_slotPanel.transform);
            }
            AddItem(0);
            AddItem(1);
            AddItem(1);
            AddItem(1);
            AddItem(1);
            AddItem(1);
            AddItem(1);
            AddItem(1);
        }

        public void AddItem(int id)
        {
            Item itemToAdd = _itemDataBase.FetchItemById(id);
            if (itemToAdd.Stackable && CheckIfItemIsInInventory(itemToAdd))
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].ID == id)
                    {
                        ItemData itemData = slots[i].transform.GetChild(0).GetComponent<ItemData>();
                        itemData.amount++;
                        itemData.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = itemData.amount.ToString();
                        break;
                    }
                }
            }
            else
            {
                for (int i = 0; i < items.Count; i++)
                {
                    if (items[i].ID == -1)
                    {
                        items[i] = itemToAdd;
                        GameObject itemObj = Instantiate(_inventoryItem);
                        itemObj.GetComponent<ItemData>().item = itemToAdd;
                        itemObj.GetComponent<ItemData>().slot = i;
                        itemObj.transform.SetParent(slots[i].transform);
                        itemObj.GetComponent<Image>().sprite = itemToAdd.Sprite;
                        itemObj.transform.position = Vector2.zero;
                        itemObj.name = itemToAdd.Title;
                        break;
                    }
                }
            }
        }

        public bool CheckIfItemIsInInventory(Item item)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].ID == item.ID)
                {
                    return true;
                }
            }
            return false;
        }
    }
}