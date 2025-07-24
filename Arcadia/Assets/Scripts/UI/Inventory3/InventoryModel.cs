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
        public InventoryModel(int slotCapacity)
        {
            
        }
        /// <summary>
        /// 아이템 추가가 가능한지에 대한 여부 검사/반환
        /// </summary>
        public bool TryAddItem(ItemSO itemSO, int quantity)
        {
            
        }
        /// <summary>
        /// 아이템 제거가 가능한지에 대한 여부 검사/반환
        /// </summary>
        public bool TryRemoveItem(ItemSO itemSO, int quantity)
        {
            
        }
    }
}