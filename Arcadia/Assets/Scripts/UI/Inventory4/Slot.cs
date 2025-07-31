using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

namespace Arcadia.UI.Inventory4
{
    public class Slot : MonoBehaviour, IDropHandler
    {
        private Inventory _inventory;
        public int id;

        // private void Start()
        // {
        //     _inventory = GameObject.Find("Inventory").GetComponent<Inventory>();
        // }
        
        public void Initialize(Inventory inventory, int slotId)
        {
            _inventory = inventory;
            id = slotId;
        }
        
        public void OnDrop(PointerEventData eventData)
        {
            if (_inventory == null)
            {
                Debug.LogError("Inventory가 초기화되지 않았습니다.");
                return;
            }

            var droppedItem = eventData.pointerDrag ? eventData.pointerDrag.GetComponent<ItemData>() : null;
            if (droppedItem == null) return;

            if (id < 0 || id >= _inventory.items.Count)
            {
                Debug.LogError($"잘못된 슬롯 id: {id}");
                return;
            }

            // 비어있는 슬롯이면 이동
            if (_inventory.items[id].ID == -1)
            {
                int prevSlot = droppedItem.slot;

                _inventory.items[prevSlot] = new Item();
                _inventory.items[id] = droppedItem.item;

                droppedItem.slot = id;
                droppedItem.transform.SetParent(transform);
                droppedItem.transform.localPosition = Vector3.zero;
            }
            else
            {
                // 스왑: prevSlot을 먼저 확보해두고 사용
                int prevSlot = droppedItem.slot;

                Transform other = transform.GetChild(0);
                var otherData = other.GetComponent<ItemData>();

                // 기존 아이템을 prevSlot으로
                otherData.slot = prevSlot;
                other.SetParent(_inventory.slots[prevSlot].transform);
                other.localPosition = Vector3.zero;

                // 드롭된 아이템을 현재 슬롯으로
                droppedItem.slot = id;
                droppedItem.transform.SetParent(transform);
                droppedItem.transform.localPosition = Vector3.zero;

                // 모델 동기화
                _inventory.items[prevSlot] = otherData.item;
                _inventory.items[id] = droppedItem.item;
            }
        }
    }
}
