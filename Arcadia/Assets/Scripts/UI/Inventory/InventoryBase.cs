using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arcadia.UI.Inventory
{
    public class InventoryBase : MonoBehaviour
    {
        [SerializeField] protected GameObject _inventoryBase;
        [SerializeField] protected GameObject _inventorySlotParent;
        [SerializeField] protected InventorySlot[] _inventorySlots;
        //베이스 초기화
        protected void Awake()
        {
            if (_inventoryBase.activeSelf)
            {
                _inventoryBase.SetActive(false);
            }
            _inventorySlots = _inventorySlotParent.GetComponentsInChildren<InventorySlot>();
        }
    }
}