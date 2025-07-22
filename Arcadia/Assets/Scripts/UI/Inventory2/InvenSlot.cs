using UnityEngine;
using UnityEngine.UI;
using TMPro;


namespace Arcadia.UI.Inventory2
{
    public class InvenSlot : MonoBehaviour
    {
        private Item  _item;
        public InventoryManager _inventoryManager;
        private Outline _outline;
        private int _itemQuantity;
        private bool equipped;
        public int _index;
        
        [Header("슬롯에 들어올 수 있는 아이템 타입")]
        [SerializeField] private ItemType _slotMask; //여기서 슬롯에 들어갈 수 있는 것들 선택가능
        
        [Header("슬롯에 있는 아이템 UI")]
        [SerializeField] private Image _itemImage; //아이템 이미지
        [SerializeField] private TextMeshProUGUI _itemCount; //아이템 수량
        
        //바깥선 컴포넌트 할당
        private void Awake()
        {
            _outline = GetComponent<Outline>();
        }

        /// <summary>
        /// 마우스로 클릭한 아이템의 정보를 보여줌
        /// </summary>
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                // _inventoryManager.SelectItem(_index);
            }
        }
        
        //바깥선이 있다면 활성화/없다면 비활성화
        private void OnEnable()
        {
            _outline.enabled = equipped;
        }
        //슬롯 세팅(초기화)
        private void Setting()
        {
            _itemImage.gameObject.SetActive(true);
            _itemImage.sprite = _item.ItemImage;
            _itemCount.text = _itemQuantity >= 1 ? _itemQuantity.ToString() : string.Empty;
        }
        //버리기 기능
        private void Cleak()
        {
            _item = null;
            _itemImage.gameObject.SetActive(false);
            _itemCount.text = string.Empty;
        }
    }
}