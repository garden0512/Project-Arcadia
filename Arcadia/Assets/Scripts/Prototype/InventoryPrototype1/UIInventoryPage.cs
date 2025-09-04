using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Arcadia.Prototype.InventoryPrototype1
{
    public class UIInventoryPage : MonoBehaviour
    {
        [SerializeField] private UIInventoryItem _uiInventoryItem;
        [SerializeField] private RectTransform _inventoryPanelTransform;
        [SerializeField] private UIInventoryDescription _uiInventoryDescription;
        [SerializeField] private MouseFollower mouseFollower;
        private List<UIInventoryItem> listOfUIItems = new List<UIInventoryItem>();
        private int currentlyDraggedItemIndex = -1;
        public event Action<int> OnDescriptionRequested, OnItemActionRequested, OnStartDragging;
        public event Action<int, int> OnSwapItems;

        private void Awake()
        {
            Hide();
            mouseFollower.Toggle(false);
            _uiInventoryDescription.ResetDescription();
        }

        public void InitializeInventoryUI(int inventorySize)
        {
            for (int i = 0; i < inventorySize; i++)
            {
                UIInventoryItem uiInventoryItem = Instantiate(_uiInventoryItem, Vector3.zero, Quaternion.identity);
                uiInventoryItem.transform.SetParent(_inventoryPanelTransform, false);
                listOfUIItems.Add(uiInventoryItem);
                uiInventoryItem.OnItemClicked += HandleItemSelection;
                uiInventoryItem.OnItemBeginDrag += HandleBeginDrag;
                uiInventoryItem.OnItemDroppedOn += HandleSwap;
                uiInventoryItem.OnItemEndDrag += HandleEndDrag;
                uiInventoryItem.OnRightMouseBtnClick += HandleShowItemActions;
            }
        }

        public void ResetAllItems()
        {
            foreach (var item in listOfUIItems)
            {
                item.ResetData();
                item.Deselect();
            }
        }

        internal void UpdateDescription(int itemIndex, Sprite itemImage, string name, string description)
        {
            _uiInventoryDescription.SetDescription(itemImage, name, description);
            DeselectAllItems();
            listOfUIItems[itemIndex].Select();
        }

        private void HandleItemSelection(UIInventoryItem obj)
        {
            int index = listOfUIItems.IndexOf(obj);
            if (index == -1)
            {
                return;
            }
            OnDescriptionRequested?.Invoke(index);
        }

        public void CreateDraggedItem(Sprite sprite, int quantity)
        {
            mouseFollower.Toggle(true);
            mouseFollower.SetData(sprite, quantity);
        }

        private void HandleBeginDrag(UIInventoryItem inventoryItem)
        {
            int index = listOfUIItems.IndexOf(inventoryItem);
            if (index == -1)
            {
                return;
            }
            currentlyDraggedItemIndex = index;
            HandleItemSelection(inventoryItem);
            OnStartDragging?.Invoke(index);
        }

        private void HandleSwap(UIInventoryItem inventoryItem)
        {
            int index = listOfUIItems.IndexOf(inventoryItem);
            if (index == -1)
            {
                return;
            }
            OnSwapItems?.Invoke(currentlyDraggedItemIndex, index);
        }

        private void ResetDraggedItem()
        {
            mouseFollower.Toggle(false);
            currentlyDraggedItemIndex = -1;
        }

        public void UpdateData(int itemIndex, Sprite itemImage, int itemQuantity)
        {
            if (listOfUIItems.Count > itemIndex)
            {
                listOfUIItems[itemIndex].SetData(itemImage, itemQuantity);
            }
        }

        private void HandleEndDrag(UIInventoryItem inventoryItem)
        {
            mouseFollower.Toggle(false);
        }

        private void HandleShowItemActions(UIInventoryItem inventoryItem)
        {
            
        }

        public void Show()
        {
            gameObject.SetActive(true);
            ResetSelection();
        }

        public void ResetSelection()
        {
            _uiInventoryDescription.ResetDescription();
            DeselectAllItems();
        }

        private void DeselectAllItems()
        {
            foreach (UIInventoryItem item in listOfUIItems)
            {
                item.Deselect();
            }
        }

        public void Hide()
        {
            gameObject.SetActive(false);
            ResetDraggedItem();
        }
    }
}
