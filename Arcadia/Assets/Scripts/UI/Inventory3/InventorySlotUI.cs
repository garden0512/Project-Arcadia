using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

namespace Arcadia.UI.Inventory3
{
    public class InventorySlotUI : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Image _itemIcon;
        [SerializeField] private TextMeshProUGUI _itemQuantity;
        private InventorySlotViewModel _inventorySlotViewModel;
        
        /// <summary>
        /// 뷰어와 뷰모델 중간다리
        /// </summary>
        public void Bind(InventorySlotViewModel inventorySlotViewModel)
        {
            _inventorySlotViewModel = inventorySlotViewModel;
            _inventorySlotViewModel.OnSlotChanged += UpdateUI;
            UpdateUI();
        }
        /// <summary>
        /// 뷰모델의 현재 상태 기준으로 UI요소 갱신
        /// </summary>
        public void UpdateUI()
        { ;
            if (_inventorySlotViewModel == null || _inventorySlotViewModel.IsEmpty)
            {
                _itemIcon.enabled = false;
                _itemQuantity.text = "";
            }
            else
            {
                _itemIcon.enabled = true;
                _itemIcon.sprite = _inventorySlotViewModel.ItemImage;
                _itemQuantity.text = _inventorySlotViewModel.Quantity.ToString();
            }
        }
        /// <summary>
        /// 슬롯을 클릭했을 때 호출
        /// </summary>
        public void OnPointerClick(PointerEventData eventData)
        {
            _inventorySlotViewModel?.HandleClick();
        }
        /// <summary>
        /// 뷰모델에 대한 이벤트 구독 해제
        /// </summary>
        public void OnDestroySubscribe()
        {
            if (_inventorySlotViewModel != null)
            {
                _inventorySlotViewModel.OnSlotChanged -= UpdateUI;
            }
        }
    }
}