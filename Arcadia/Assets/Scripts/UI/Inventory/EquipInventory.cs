using UnityEngine;
using TMPro;

namespace Arcadia.UI.Inventory
{
    public class EquipInventory : InventoryBase
    {
        public static bool IsInventoryActive = false;
        
        [Header("현재 플레이어 수치")]
        [SerializeField] private TextMeshProUGUI _damageLabel;
        [SerializeField] private TextMeshProUGUI _armorLabel;

        private new void Awake()
        {
            base.Awake();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (_inventoryBase.activeInHierarchy)
                {
                    _inventoryBase.SetActive(false);
                    IsInventoryActive = false;
                }
                else
                {
                    _inventoryBase.SetActive(true);
                    IsInventoryActive = true;
                }
            }
        }
    }
}