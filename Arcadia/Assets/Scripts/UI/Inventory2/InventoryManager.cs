using TMPro;
using UnityEngine;

namespace Arcadia.UI.Inventory2
{
    public class InventoryManager : MonoBehaviour
    {
        private InvenSlot[] _invenSlots;
        private bool _isInventoryOpen;
        [SerializeField] private GameObject _inventoryWindow;
        [SerializeField] private Transform _slotPanel;

        [Header("아이템 정보")]
        private InvenSlot _selectedSlot;
        private int _selectedItemIndex;
        [SerializeField] private TextMeshProUGUI _SelectedItemName; //아이템 이름
        [SerializeField] private TextMeshProUGUI _selectedItemDescription; //아이템 설명
        [SerializeField] private TextMeshProUGUI _SelectedItemStatName; //아이템 수치 이름
        [SerializeField] private TextMeshProUGUI _SelectedItemStatValue; //아이템 이름
        
        /// <summary>
        /// 인벤토리창 초기화
        /// </summary>
        private void Start()
        {
            _inventoryWindow.SetActive(false);
            _invenSlots = new InvenSlot[_slotPanel.childCount];
            for (int i = 0; i < _invenSlots.Length; i++)
            {
                _invenSlots[i] = _slotPanel.GetChild(i).GetComponent<InvenSlot>();
                _invenSlots[i]._index = i;
                _invenSlots[i]._inventoryManager = this;
            }

            // ClearSelectedItemWindow();
        }
        /// <summary>
        /// 상시 검사
        /// </summary>
        public void Update()
        {
            TryOpenInventory();
        }
        
        /// <summary>
        /// 인벤토리 오픈하는 기능
        /// </summary>
        private void TryOpenInventory()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (!_isInventoryOpen)
                {
                    _isInventoryOpen = true;
                    _inventoryWindow.SetActive(true);
                }
                else
                {
                    _isInventoryOpen = false;
                    _inventoryWindow.SetActive(false);
                }
            }
        }
        
        /// <summary>
        /// 인벤이 열려있는지를 판단하는 메서드
        /// </summary>
        /// <returns></returns>
        public bool IsOpen()
        {
            return _isInventoryOpen;
        }

        private void AddItem()
        {
            
        }

    }
}