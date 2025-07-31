using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;

namespace Arcadia.UI.Inventory4
{
    public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public Item item;
        public int amount;
        public int slot;
        private Inventory _inventory;
        private Vector2 offset;

        private void Start()
        {
            _inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (item != null)
            {
                offset = eventData.position - new Vector2(this.transform.position.x, this.transform.position.y);
                this.transform.SetParent(this.transform.parent.parent);
                this.transform.position = eventData.position - offset;
                GetComponent<CanvasGroup>().blocksRaycasts = false;
            }
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (item != null)
            {
                this.transform.position = eventData.position - offset;
            }
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            this.transform.SetParent(_inventory.slots[slot].transform);
            this.transform.position = _inventory.slots[slot].transform.position;
            GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
    }
}