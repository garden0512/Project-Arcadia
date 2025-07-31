using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace Arcadia.UI.Inventory4
{
    public class Slot : MonoBehaviour, IDropHandler
    {
        private Inventory _inventory;
        public int id;

        private void Start()
        {
            _inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        }
        
        public void OnDrop(PointerEventData eventData)
        {
            ItemData droppedItem = eventData.pointerDrag.GetComponent<ItemData>();
            Debug.Log(_inventory.items[id].ID);
            if (_inventory.items[id].ID == -1)
            {
                _inventory.items[droppedItem.slot] = new Item();
                _inventory.items[id] = droppedItem.item;
                droppedItem.slot = id;
            }
            else
            {
                Transform item = this.transform.GetChild(0);
                item.GetComponent<ItemData>().slot = droppedItem.slot;
                item.transform.SetParent(_inventory.slots[droppedItem.slot].transform);
                item.transform.position = _inventory.slots[droppedItem.slot].transform.position;
                droppedItem.slot = id;
                droppedItem.transform.SetParent(this.transform);
                droppedItem.transform.position = this.transform.position;
                _inventory.items[droppedItem.slot] = item.GetComponent<ItemData>().item;
                _inventory.items[id] = droppedItem.item;
            }
        }
    }
}
