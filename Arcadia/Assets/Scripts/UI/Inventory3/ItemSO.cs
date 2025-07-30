using UnityEngine;

namespace Arcadia.UI.Inventory3
{
    [System.Flags]
    public enum ItemType
    {
        None = 0b_0000_0000,
        Weapon = 0b_0000_0001,
        ETC = 0b_0000_0010,
    }

    [System.Flags]
    public enum ItemColor
    {
        None = 0b_0000_0000_0000,
        Red = 0b_0000_0000_0001,
        Orange = 0b_0000_0000_0010,
        Yellow = 0b_0000_0000_0100,
        Green = 0b_0000_0000_1000,
        Blue = 0b_0000_0001_0000,
        Purple = 0b_0000_0010_0000,
        White = 0b_0000_0100_0000,
        Black = 0b_0000_1000_0000,
    }
    
    [CreateAssetMenu(fileName = "ItemSO", menuName = "Add Item/ItemSO")]
    public class ItemSO : ScriptableObject
    {
        [Header("아이템 ID")]
        [SerializeField] private int _itemID;
        public int ItemID => _itemID;
        
        [Header("아이템 분류")]
        [SerializeField] private ItemType _itemType;
        public ItemType ItemType => _itemType;
        
        [Header("아이템 고유 색상")]
        [SerializeField] private ItemColor _itemColor;
        public ItemColor ItemColor => _itemColor;
        
        [Header("아이템 중첩 가능 여부")]
        [SerializeField] private bool _isOverlapable;
        public bool IsOverlapable => _isOverlapable;
        
        [Header("아이템 사용 가능 여부")]
        [SerializeField] private bool _isInteractable;
        public bool IsInteractable => _isInteractable;
        
        [Header("아이템 사용 후 사라짐 여부")]
        [SerializeField] private bool _isDisappearable;
        public bool IsDisappearable => _isDisappearable;
        
        [Header("아이템 이미지")]
        [SerializeField] private Sprite _itemImage;
        public Sprite ItemImage => _itemImage;
    }
}
