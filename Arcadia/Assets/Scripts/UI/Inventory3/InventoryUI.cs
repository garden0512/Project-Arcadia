using UnityEngine;

namespace Arcadia.UI.Inventory3
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private InventorySlotUI _inventorySlotUI;
        [SerializeField] private Transform _slotPanel;
        private InventoryViewModel _inventoryViewModel;
        private InventorySlotUI[] _slotUIs;
        
        /// <summary>
        /// 뷰어와 뷰모델 중개
        /// </summary>
        public void Bind(InventoryViewModel inventoryViewModel)
        {
            _inventoryViewModel = inventoryViewModel;
            int SlotCount = _inventoryViewModel.InventorySlotViewModels.Count;
            _slotUIs = new InventorySlotUI[SlotCount];
            for (int i = 0; i < SlotCount; i++)
            {
                var slotViewModel = _inventoryViewModel.InventorySlotViewModels[i];
                GameObject slotObject = new GameObject($"InventorySlotUI_{i}");
                slotObject.transform.SetParent(_slotPanel, false);
                var slotUI = slotObject.AddComponent<InventorySlotUI>();
                slotUI.Bind(slotViewModel);
                _slotUIs[i] = slotUI;
            }
        }
        /// <summary>
        /// 이벤트 구독 해제
        /// </summary>
        public void OnDestroySubscribe()
        {
            if (_slotUIs == null)
            {
                return;
            }

            foreach (var slotUI in _slotUIs)
            {
                slotUI.OnDestroySubscribe();
            }
        }
        /// <summary>
        /// 전체 UI를 최신상태로 갱신
        /// </summary>
        public void RefreshAll()
        {
            if (_slotUIs == null)
            {
                return;
            }

            foreach (var slotUI in _slotUIs)
            {
                slotUI.UpdateUI();
            }
        }
    }
}