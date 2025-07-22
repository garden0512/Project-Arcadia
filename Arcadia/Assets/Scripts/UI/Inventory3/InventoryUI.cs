using UnityEngine;

namespace Arcadia.UI.Inventory3
{
    public class InventoryUI : MonoBehaviour
    {
        [SerializeField] private InventorySlotUI _inventorySlotUI;
        private Transform _slotPanel;
        private InventoryViewModel _inventoryViewModel;
        private InventorySlotUI[] _slotUIs;
        
        /// <summary>
        /// 뷰어와 뷰모델 중개
        /// </summary>
        public void Bind(InventoryViewModel inventoryViewModel)
        {
            
        }
        /// <summary>
        /// 이벤트 구독 해제
        /// </summary>
        public void OnDestroySubscribe()
        {
            //당장은 쓸모없을듯?
        }
        /// <summary>
        /// 전체 UI를 최신상태로 갱신
        /// </summary>
        public void RefreshAll()
        {
            
        }
    }
}