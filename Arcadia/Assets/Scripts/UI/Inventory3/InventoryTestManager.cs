using UnityEngine;

namespace Arcadia.UI.Inventory3
{
    public class InventoryTestManager : MonoBehaviour
    {
        [SerializeField] private InventoryModel _inventoryModel;
        [SerializeField] private ItemSO _itemSo;
        [SerializeField] private Transform _slotsPanel;
        [SerializeField] private int _slotCount;
        [SerializeField] private InventoryViewModel _inventoryViewModel;
        [SerializeField] private InventoryUI _inventoryUI;
        

        private void Start()
        {
            _inventoryModel.InventoryModelInit(_slotsPanel, _slotCount);
            _inventoryViewModel.Bind(_inventoryModel);
            _inventoryUI.Bind(_inventoryViewModel);
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.O))
            {
                Debug.Log("아이템 추가");
                _inventoryViewModel.TryAddItem(_itemSo, 1);
            }

            if (Input.GetKeyDown(KeyCode.X))
            {
                Debug.Log("아이템 제거");
                _inventoryViewModel.TryRemoveItem(_itemSo, 1);
            }
        }
    }
}
