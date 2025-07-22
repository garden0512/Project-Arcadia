using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arcadia.UI.Inventory
{
    [System.Flags]
    public enum ItemType
    {
        //여기에 실제 아이템들 ID 넣으면 됨
        None = 0b000,
        Weapon = 0b001,
        Dummy = 0b010,
    }
    
    [CreateAssetMenu(fileName = "Item", menuName = "Add Item/Item")]
    public class Item : ScriptableObject
    {
        [Header("아이템 고유 ID")]
        [SerializeField] private int _itemID;
        public int ItemID
        {
            get
            {
                return _itemID;
            }
        }
        
        [Header("아이템 중첩 가능 여부")]
        [SerializeField] private bool _canOverlap;
        public bool CanOverlap
        {
            get
            {
                return _canOverlap;
            }
        }
        
        [Header("아이템 상호작용 가능 여부")]
        [SerializeField] private bool _isInteractivity;
        public bool IsInteractivity
        {
            get
            {
                return _isInteractivity;
            }
        }
        
        [Header("아이템 사용 후 사라짐 여부")]
        [SerializeField] private bool _isConsumable;
        public bool IsConsumable
        {
            get
            {
                return  _isConsumable;
            }
        }
        
        [Header("아이템 쿨타임")]
        [SerializeField] private ItemType _itemType;
        public ItemType ItemType
        {
            get
            {
                return _itemType;
            }
        }
        
        [Header("인벤에서의 아이템 이미지")]
        [SerializeField] private Sprite _itemSprite;
        public Sprite Image
        {
            get
            {
                return _itemSprite;
            }
        }
    }
}