using UnityEngine;

namespace Arcadia.UI.Inventory
{
    public class InventoryMain : InventoryBase
    {
        public static bool IsInventoryActive = false;

        private new void Awake()
        {
            base.Awake();
        }

        private void Update()
        {
            TryOpenInventory();
        }

        private void TryOpenInventory()
        {
            //다른 UI상태들의 상태에 따라서 열릴지 말지 결정되는 기능 넣기
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (!IsInventoryActive)
                {
                    OpenInventory();
                }
                else
                {
                    CloseInventory();
                }
            }
        }

        private void OpenInventory()
        {
            IsInventoryActive = true;
            _inventoryBase.SetActive(true);
        }

        private void CloseInventory()
        {
            IsInventoryActive = false;
            _inventoryBase.SetActive(false);
        }
        
        //특정 아이템 슬롯에 아이템 등록
        public void AcquireItem(Item item, InventorySlot targetSlot, int count = 1)
        {
            if (item.CanOverlap)
            {
                if (targetSlot.Item != null && targetSlot.IsMask(item))
                {
                    if (targetSlot.Item.ItemID == item.ItemID)
                    {
                        targetSlot.UpdateSlotCount(count);
                    }
                }
            }
            else
            {
                targetSlot.AddItem(item, count);
            }
        }

        public void AcquireItem(Item item, int count = 1)
        {
            if (item.CanOverlap)
            {
                for (int i = 0; i < _inventorySlots.Length; i++)
                {
                    if (_inventorySlots[i].Item != null && _inventorySlots[i].IsMask(item))
                    {
                        if (_inventorySlots[i].Item.ItemID == item.ItemID)
                        {
                            _inventorySlots[i].UpdateSlotCount(count);
                            return;
                        }
                    }
                }
            }

            for (int i = 0; i < _inventorySlots.Length; i++)
            {
                if (_inventorySlots[i].Item == null && _inventorySlots[i].IsMask(item))
                {
                    _inventorySlots[i].AddItem(item, count);
                    return;
                }
            }
        }
    }
}