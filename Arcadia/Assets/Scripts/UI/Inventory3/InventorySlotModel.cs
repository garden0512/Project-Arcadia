using Arcadia.UI.Inventory3;
using UnityEngine;

namespace Arcadia
{
    public class InventorySlotModel : MonoBehaviour
    {
        private ItemSO _itemSO;
        private int _quantity;
        
        /// <summary>
        /// 완전 새로운 아이템을 슬롯에 추가 / 기존의 아이템에 덮어쓰기
        /// </summary>
        public void AssignItem(ItemSO itemSO, int quantity)
        {
            
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
            
        }
        /// <summary>
        /// 아이템 수량 감소
        /// </summary>
        public void SubtractItem(ItemSO itemSO, int quantity)
        {
            
        }
        /// <summary>
        /// 빈 슬롯인지 검사
        /// </summary>
        public void IsEmptySlot()
        {
            
        }
        /// <summary>
        /// 실제 중첩이 가능한지 검사
        /// </summary>
        public bool CanStack(ItemSO itemSO)
        {
            
        }
        /// <summary>
        /// 같은 아이템인지 검사
        /// </summary>
        public bool IsSameItem(ItemSO itemSO)
        {
            
        }
        /// <summary>
        /// 현재 슬롯에 추가로 넣을 수 있는 아이템 수량 체크
        /// </summary>
        public int GetRemaining()
        {
            
        }
    }
}