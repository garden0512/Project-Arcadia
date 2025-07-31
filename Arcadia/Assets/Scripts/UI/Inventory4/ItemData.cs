using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Arcadia.UI.Inventory4
{
    public class ItemData : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        public Item item;
        public int amount;
        public int slot;

        private Inventory _inventory;
        private Vector2 offset;
        private Transform originalParent;
        private int originalSlot;

        // Inventory에서 호출
        public void Initialize(Inventory inventory, int slotIndex, Item itemRef)
        {
            _inventory = inventory;
            slot = slotIndex;
            item = itemRef;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (item == null) return;

            originalParent = transform.parent;
            originalSlot = slot;

            offset = eventData.position - (Vector2)transform.position;

            // 드래그 중에는 상위로 빼서 Raycast 잘 받게 (필요시 Canvas 상 적절한 레이어/컨테이너를 사용)
            transform.SetParent(originalParent.parent);
            transform.position = eventData.position - offset;

            var cg = GetComponent<CanvasGroup>();
            if (cg != null) cg.blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (item == null) return;
            transform.position = eventData.position - offset;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            var cg = GetComponent<CanvasGroup>();
            if (cg != null) cg.blocksRaycasts = true;

            // 드롭 지점이 Slot(또는 그 자식)인지 판정
            bool droppedOnSlot =
                eventData.pointerEnter != null &&
               (eventData.pointerEnter.GetComponent<Slot>() != null ||
                eventData.pointerEnter.GetComponentInParent<Slot>() != null);

            // 유효한 슬롯에 드롭되었으면 Slot.OnDrop이 부모/위치/모델을 이미 정리함 → 건드리지 않음
            if (droppedOnSlot) return;

            // 실패한 드롭이면 원래 슬롯으로 복귀
            if (_inventory == null || originalSlot < 0 || originalSlot >= _inventory.slots.Count)
            {
                Debug.LogError("OnEndDrag 중 Inventory가 null이거나 잘못된 슬롯 index");
                return;
            }

            transform.SetParent(_inventory.slots[originalSlot].transform);
            transform.localPosition = Vector3.zero;
            slot = originalSlot;
        }
    }
}
