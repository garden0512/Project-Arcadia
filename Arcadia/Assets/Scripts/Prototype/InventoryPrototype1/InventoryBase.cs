using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arcadia.Prototype.InventoryPrototype1
{
    abstract public class InventoryBase : MonoBehaviour
    {
        [SerializeField] protected GameObject mInventoryBase;
        [SerializeField] protected GameObject mInventorySlotsParent;
        
        /// <summary>
        /// 인벤토리 베이스 초기화
        /// </summary>
        protected void Awake()
        {
            if (mInventoryBase.activeSelf)
            {
                mInventoryBase.SetActive(false);
            }

            mSlots = mInventorySlotsParent.GetComponentsInChildren<InventorySlot>();
        }
    }
}