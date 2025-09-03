using UnityEngine;
using System.Collections.Generic;
using System.Collections;

namespace Arcadia.Prototype.InventoryPrototype1
{
    [System.Flags]
    public enum ItemType
    {
        NONE = 0b_0000_0000,
        Weapon = 0b_0000_0001,
        ETC = 0b_0000_0010,
        
        
    }
    
    [CreateAssetMenu(fileName = "ItemSample", menuName = "Add ItemSample/ItemSample")]
    public class Item : ScriptableObject
    {
        [Header("고유 아이템 ID")] 
        [SerializeField] private int mItemID;
        public int ItemID
        {
            get
            {
                return mItemID;
            }
        }

        [Header("중첩 가능 여부")]
        [SerializeField] private bool mCanOverlap;

        public bool CanOverlap
        {
            get
            {
                return mCanOverlap;
            }
        }

        [Header("상호작용 가능 여부")]
        [SerializeField] private bool mIsInteractivity;
        public bool IsInteractivity
        {
            get
            {
                return mIsInteractivity;
            }
        }

        [Header("상호작용 후 사라짐 여부")]
        [SerializeField] private bool mIsConsumable;
        public bool IsConsumable
        {
            get
            {
                return mIsConsumable;
            }
        }

        [Header("사용시 쿨타임")]
        [SerializeField] private float mItemCooltime = -1;
        public float Cooltime
        {
            get
            {
                return mItemCooltime;
            }
        }

        [Header("아이템 타입")]
        [SerializeField] private ItemType mItemType;
        public ItemType Type
        {
            get
            {
                return mItemType;
            }
        }

        [Header("인벤토리 아이템 아이콘")] 
        [SerializeField] private Sprite mItemImage;

        public Sprite Image
        {
            get
            {
                return mItemImage;
            }
        }
    }
}