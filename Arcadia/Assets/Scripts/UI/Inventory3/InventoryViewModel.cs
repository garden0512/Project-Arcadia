using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace Arcadia.UI.Inventory3
{
    public class InventoryViewModel : MonoBehaviour
    {
        private InventoryModel _inventoryModel;
        private List<InventorySlotViewModel> _inventorySlotViewModels;
        public IReadOnlyList<InventorySlotViewModel> InventorySlotViewModels;

        /// <summary>
        /// View들이랑 Model들을 연결하는 역할(=바인딩?)
        /// </summary>
        public void Bind(InventoryModel inventoryModel)
        {
            
        }
        /// <summary>
        /// 현재 뷰모델에서 Model로 요청, 전체적인 처리 성공 여부 반환
        /// </summary>
        public bool TryAddItem(ItemSO item, int quantity)
        {
            
        }
        /// <summary>
        /// 현재 뷰모델에서 Model로 요청, 전체적인 처리 성공 여부 반환
        /// </summary>
        public bool TryRemoveItem(ItemSO item, int quantity)
        {
            
        }
        /// <summary>
        /// 슬롯 간 아이템 이동 처리(드래그 앤 드롭 관련)
        /// </summary>
        public bool MoveItem(int fromIndex, int toIndex)
        {
            
        }

        /// <summary>
        /// 슬롯 클릭 이벤트 처리
        /// </summary>
        public void HandleSlotClicked(int slotIndex)
        {
            
        }

        /// <summary>
        /// 현재 뷰모델 상태 기준으로 모든 슬롯 뷰모델 갱신
        /// </summary>
        public void Refresh()
        {
            
        }
    }
}