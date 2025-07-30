using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace Arcadia.UI.Inventory3
{
    public class InventoryModel : MonoBehaviour
    {
        private List<InventorySlotModel> _inventorySlots;
        private int _slotCapacity;
        public IReadOnlyList<InventorySlotModel> InventorySlots => _inventorySlots;
        
        /// <summary>
        /// InventoryModel 생성자
        /// </summary>
        public void InventoryModelInit(Transform parentPanel, int slotCapacity)
        {
            _slotCapacity = slotCapacity;
            _inventorySlots = new List<InventorySlotModel>(_slotCapacity);
            for (int i = 0; i < _slotCapacity; i++)
            {
                var slotObject = new GameObject($"Slot{i}");
                var SlotModel = slotObject.AddComponent<InventorySlotModel>();
                slotObject.transform.SetParent(parentPanel, false);
                _inventorySlots.Add(SlotModel);
            }
        }
        /// <summary>
        /// 아이템 추가가 가능한지에 대한 여부 검사/반환
        /// </summary>
        public bool TryAddItem(ItemSO itemSO, int quantity)
        {
            if (itemSO == null || quantity <= 0)
            {
                Debug.LogError("InventoryModel::TryAddItem : 아이템 또는 아이템 수량이 비정상적입니다.");
                return false;
            }

            if (itemSO.IsOverlapable)
            {
                foreach (var slot in _inventorySlots)
                {
                    if (slot.CanStack(itemSO))
                    {
                        int slotRemained = slot.GetRemaining();
                        int toAdd = Mathf.Min(slotRemained, quantity);
                        slot.AddItem(itemSO, toAdd);
                        quantity -= toAdd;
                        if (quantity <= 0)
                        {
                            return true;
                        }
                    }
                }
            }

            foreach (var slot in _inventorySlots)
            {
                if (slot.IsEmptySlot())
                {
                    int toAdd = itemSO.IsOverlapable ? Mathf.Min(slot.GetRemaining(), quantity) : 1;
                    slot.AssignItem(itemSO, toAdd);
                    quantity -= toAdd;
                    if (quantity <= 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// 아이템 제거가 가능한지에 대한 여부 검사/반환
        /// </summary>
        public bool TryRemoveItem(ItemSO itemSO, int quantity)
        {
            if (itemSO == null || quantity <= 0)
            {
                Debug.LogError("InventoryModel::TryRemoveItem : 아이템 또는 아이템 수량이 비정상적입니다.");
                return false;
            }

            foreach (var slot in _inventorySlots)
            {
                if (slot.IsSameItem(itemSO))
                {
                    int slotQuantity = slot.GetRemaining() + slot.Quantity();
                    int toRemove = Mathf.Min(slot.Quantity(), quantity);
                    slot.SubtractItem(itemSO, toRemove);
                    quantity -= toRemove;
                    if (slot.IsEmptySlot())
                    {
                        slot.ClearSlot();
                    }

                    if (quantity <= 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool MoveItem(InventorySlotModel fromSlot, InventorySlotModel toSlot)
        {
            if (fromSlot.IsEmptySlot())
            {
                toSlot.AssignItem(fromSlot.ItemSO, fromSlot.Quantity());
                fromSlot.ClearSlot();
                return true;
            }

            if (toSlot.ItemSO == fromSlot.ItemSO)
            {
                int maxStack = toSlot.MaxQuantity;
                int total = toSlot.Quantity() + fromSlot.Quantity();
                if (total <= maxStack)
                {
                    toSlot.AddItem(fromSlot.ItemSO, toSlot.Quantity());
                    fromSlot.ClearSlot();
                    return true;
                }
                else
                {
                    int canAdd = maxStack - toSlot.Quantity();
                    if (canAdd > 0)
                    {
                        toSlot.AddItem(fromSlot.ItemSO, canAdd);
                        fromSlot.SubtractItem(toSlot.ItemSO, canAdd);
                        return true;
                    }
                }
            }
            var tempItem = toSlot.ItemSO;
            var tempQuantity = toSlot.Quantity();

            toSlot.AssignItem(fromSlot.ItemSO, fromSlot.Quantity());
            fromSlot.AssignItem(tempItem, tempQuantity);
            return true;
        }
    }
}