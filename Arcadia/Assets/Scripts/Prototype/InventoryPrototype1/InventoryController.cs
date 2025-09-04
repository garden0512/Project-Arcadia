using UnityEngine;
using System;
using System.Collections.Generic;

namespace Arcadia.Prototype.InventoryPrototype1
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private UIInventoryPage _uiInventoryPageWithoutFrameTitle;
        [SerializeField] private InventorySO _inventoryData;
        public int inventorySize = 10;
        public List<InventoryItem> initialItems = new List<InventoryItem>();

        private void Start()
        {
            PrepareUI();
            PrepareInventoryData();
        }

        private void PrepareInventoryData()
        {
            _inventoryData.Initialize();
            _inventoryData.OnInventoryUpdated += UpdateInventoryUI;
            foreach (InventoryItem item in initialItems)
            {
                if (item.IsEmpty)
                {
                    continue;
                }
                _inventoryData.AddItem(item);
            }
        }

        private void UpdateInventoryUI(Dictionary<int, InventoryItem> inventoryState)
        {
            _uiInventoryPageWithoutFrameTitle.ResetSelection();
            foreach (var item in inventoryState)
            {
                _uiInventoryPageWithoutFrameTitle.UpdateData(item.Key, item.Value.item.ItemImage, item.Value.quantity);
            }
        }

        private void PrepareUI()
        {
            _uiInventoryPageWithoutFrameTitle.InitializeInventoryUI(inventorySize);
            this._uiInventoryPageWithoutFrameTitle.OnDescriptionRequested += HandleDescriptionRequest;
            this._uiInventoryPageWithoutFrameTitle.OnSwapItems += HandleSwapItems;
            this._uiInventoryPageWithoutFrameTitle.OnStartDragging += HandleDragging;
            this._uiInventoryPageWithoutFrameTitle.OnItemActionRequested += HandleItemActionRequest;
        }

        private void HandleDescriptionRequest(int itemIndex)
        {
            InventoryItem inventoryItem = _inventoryData.GetItemAt(itemIndex);
            if (inventoryItem.IsEmpty)
            {
                _uiInventoryPageWithoutFrameTitle.ResetSelection();
                return;
            }
            ItemsSO item = inventoryItem.item;
            _uiInventoryPageWithoutFrameTitle.UpdateDescription(itemIndex, item.ItemImage, item.Name, item.Description);
        }

        private void HandleSwapItems(int itemIndex_1, int itemIndex_2)
        {
            _inventoryData.SwapItems(itemIndex_1, itemIndex_2);
        }

        private void HandleDragging(int itemIndex)
        {
            InventoryItem inventoryItem = _inventoryData.GetItemAt(itemIndex);
            if (inventoryItem.IsEmpty)
            {
                return;
            }
            _uiInventoryPageWithoutFrameTitle.CreateDraggedItem(inventoryItem.item.ItemImage, inventoryItem.quantity);
        }

        private void HandleItemActionRequest(int itemIndex)
        {
            
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (_uiInventoryPageWithoutFrameTitle.isActiveAndEnabled == false)
                {
                    _uiInventoryPageWithoutFrameTitle.Show();
                    foreach (var item in _inventoryData.GetCurrentInventoryState())
                    {
                        _uiInventoryPageWithoutFrameTitle.UpdateData(item.Key, item.Value.item.ItemImage, item.Value.quantity);
                    }
                }
                else
                {
                    _uiInventoryPageWithoutFrameTitle.Hide();
                }
            }
        }
    }
}