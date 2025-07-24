using System.Collections.Generic;
using System.Collections;
using UnityEngine;

namespace Arcadia.UI.Inventory3
{
    public class InventoryViewModel : MonoBehaviour
    {
        private InventoryModel _inventoryModel;
        private List<InventorySlotViewModel> _inventorySlotViewModels;
        public IReadOnlyList<InventorySlotViewModel> InventorySlotViewModels => _inventorySlotViewModels;

        /// <summary>
        /// View들이랑 Model들을 연결하는 역할(=바인딩?)
        /// </summary>
        public void Bind(InventoryModel inventoryModel)
        {
            _inventoryModel = inventoryModel;
            _inventorySlotViewModels = new List<InventorySlotViewModel>();
            foreach (var slotModel in inventoryModel.InventorySlots)
            {
                GameObject SlotViewModel = new GameObject("InventorySlotViewModel");
                InventorySlotViewModel slotViewModel = SlotViewModel.AddComponent<InventorySlotViewModel>();
                slotViewModel.Bind(slotModel);
                _inventorySlotViewModels.Add(slotViewModel);
            }
        }
        /// <summary>
        /// 현재 뷰모델에서 Model로 요청, 전체적인 처리 성공 여부 반환
        /// </summary>
        public bool TryAddItem(ItemSO item, int quantity)
        {
            bool result = _inventoryModel.TryAddItem(item, quantity);
            if (result)
            {
                Refresh();
            }
            return result;
        }
        /// <summary>
        /// 현재 뷰모델에서 Model로 요청, 전체적인 처리 성공 여부 반환
        /// </summary>
        public bool TryRemoveItem(ItemSO item, int quantity)
        {
            bool result = _inventoryModel.TryRemoveItem(item, quantity);
            if (result)
            {
                Refresh();
            }
            return result;
        }
        /// <summary>
        /// 슬롯 간 아이템 이동 처리(드래그 앤 드롭 관련)
        /// </summary>
        public bool MoveItem(int fromIndex, int toIndex)
        {
            if (fromIndex == toIndex)
            {
                return false;
            }
            var fromSlot = _inventoryModel.InventorySlots[fromIndex];
            var toSlot = _inventoryModel.InventorySlots[toIndex];
            bool result = _inventoryModel.MoveItem(fromSlot, toSlot);
            if (result)
            {
                Refresh();
            }
            return result;
        }

        /// <summary>
        /// 슬롯 클릭 이벤트 처리
        /// </summary>
        public void HandleSlotClicked(int slotIndex)
        {
            Debug.Log($"slot{slotIndex}, 아이템{_inventoryModel.InventorySlots[slotIndex].ItemSO.ItemID}");
        }

        /// <summary>
        /// 현재 뷰모델 상태 기준으로 모든 슬롯 뷰모델 갱신
        /// </summary>
        public void Refresh()
        {
            foreach (var viewModel in _inventorySlotViewModels)
            {
                viewModel.UpdateFromModel();
            }
        }
    }
}