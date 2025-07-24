using UnityEngine;

namespace Arcadia.UI.Inventory3
{
    public class InventorySlotModel : MonoBehaviour
    {
        private ItemSO _itemSO;
        private int _quantity;
        [SerializeField] private int _maxQuantity = 128;
        public ItemSO ItemSO => _itemSO;
        public int MaxQuantity => _maxQuantity;
        public int Quantity() => _quantity;
        /// <summary>
        /// 완전 새로운 아이템을 슬롯에 추가 / 기존의 아이템에 덮어쓰기
        /// </summary>
        public void AssignItem(ItemSO itemSO, int quantity)
        {
            if (itemSO == null || quantity <= 0)
            {
                ClearSlot();
            }
            else
            {
                _itemSO = itemSO;
                _quantity = quantity;
            }
        }
        /// <summary>
        /// 슬롯 비움(초기화)
        /// </summary>
        public void ClearSlot()
        {
            _itemSO = null;
            _quantity = 0;
        }
        /// <summary>
        /// 슬롯에 아이템 수량 증가
        /// </summary>
        public void AddItem(ItemSO itemSO, int quantity)
        {
            if (itemSO == null || quantity <= 0)
            {
                Debug.LogError("InventorySlotModel::AddItem : 아이템이 없거나 개수가 음수값입니다.(양수만 가능)");
            }
            else if (_itemSO.ItemID != itemSO.ItemID || _itemSO.ItemColor != itemSO.ItemColor ||
                     _itemSO.ItemType != itemSO.ItemType)
            {
                Debug.LogError("InventorySlotModel::AddItem : 아이템의 타입/ID/컬러 중 하나가 일치하지 않은 것이 들어왔습니다.");
            }
            else
            {
                _quantity += quantity;
            }
        }
        /// <summary>
        /// 아이템 수량 감소
        /// </summary>
        public void SubtractItem(ItemSO itemSO, int quantity)
        {
            if (itemSO == null || quantity <= 0)
            {
                Debug.LogError("InventorySlotModel::AddItem : 아이템이 없거나 개수가 음수값입니다.(양수만 가능)");
            }
            else if (_itemSO.ItemID != itemSO.ItemID || _itemSO.ItemColor != itemSO.ItemColor ||
                     _itemSO.ItemType != itemSO.ItemType)
            {
                Debug.LogError("InventorySlotModel::AddItem : 아이템의 타입/ID/컬러 중 하나가 일치하지 않은 것이 들어왔습니다.");
            }
            else
            {
                _quantity -= quantity;
            }
        }
        /// <summary>
        /// 빈 슬롯인지 검사
        /// </summary>
        public bool IsEmptySlot()
        {
            if (_itemSO == null && _quantity == 0)
            {
                return true;
            }
            else if (_quantity < 0)
            {
                Debug.LogError("InventorySlotModel::IsEmptySlot : 아이템 수량이 비정상적으로 적습니다");
            }

            return false;
        }
        /// <summary>
        /// 실제 중첩이 가능한지 검사
        /// </summary>
        public bool CanStack(ItemSO itemSO)
        {
            if (this.IsSameItem(itemSO) == true && this.GetRemaining() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 같은 아이템인지 검사
        /// </summary>
        public bool IsSameItem(ItemSO itemSO)
        {
            if (itemSO.ItemID == _itemSO.ItemID && itemSO.ItemColor == _itemSO.ItemColor &&
                itemSO.ItemType == _itemSO.ItemType)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// 현재 슬롯에 추가로 넣을 수 있는 아이템 수량 체크
        /// </summary>
        public int GetRemaining()
        {
            return (_maxQuantity - _quantity);
        }
    }
}