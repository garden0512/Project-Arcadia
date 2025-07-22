using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

namespace Arcadia.UI.Inventory2
{
    [System.Flags]
    public enum ItemType
    {
        None = 0b0000_0000_0000,
        Weapon = 0b0000_0000_0001,
        Dummy = 0b0000_0000_0010,
        
    }

    [System.Flags]
    public enum ItemColor
    {
        None = 0b0000_0000_0000,
        Red = 0b0000_0000_0001,
        Orange = 0b0000_0000_0010,
        Yellow = 0b0000_0000_0100,
        Green = 0b0000_0000_1000,
        Blue = 0b0000_0001_0000,
        Purple = 0b0000_0010_0000,
        White = 0b0000_0100_0000,
        Black = 0b0000_1000_0000,
    }
    
    [CreateAssetMenu(fileName = "Item", menuName = "Add Item/Item")]
    public class Item : ScriptableObject
    {
        [Header("아이템 고유 ID")]
        [SerializeField] private int _itemId;
        public int ItemId => _itemId;
        
        [Header("아이템 타입")]
        [SerializeField] private ItemType _itemType;
        public ItemType ItemType => _itemType;
        
        [Header("아이템 색")]
        [SerializeField] private ItemColor _itemColor;
        public ItemColor ItemColor => _itemColor;
        
        [Header("아이템 중첩 가능 여부")]
        [SerializeField] private bool _canCombine;
        public bool CanCombine => _canCombine;

        [Header("인벤토리에서의 아이템 이미지")]
        [SerializeField] private Sprite _itemImage;
        public Sprite ItemImage => _itemImage;
    }
}