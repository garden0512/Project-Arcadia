using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace Arcadia.Prototype.InventoryPrototype1
{
    public class UIInventoryPage : MonoBehaviour
    {
        [SerializeField] private UIInventoryItem _uiInventoryItem;
        [SerializeField] private RectTransform _inventoryPanelTransform;
        [SerializeField] private UIInventoryDescription _uiInventoryDescription;
        [SerializeField] private MouseFollower mouseFollower;
        private List<UIInventoryItem> listOfUIItems = new List<UIInventoryItem>();
        public Sprite image, image2;
        public int quantity;
        public string title, description;
        private int currentlyDraggedItemIndex = -1;

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

        private void HandleItemSelection(UIInventoryItem obj)
        {
            _uiInventoryDescription.SetDescription(image, title, description);
            listOfUIItems[0].Select();
        }

        private void HandleBeginDrag(UIInventoryItem inventoryItem)
        {
            int index = listOfUIItems.IndexOf(inventoryItem);
            if (index == -1)
            {
                return;
            }
            currentlyDraggedItemIndex = index;
            mouseFollower.Toggle(true);
            mouseFollower.SetData(index == 0? image : image2, quantity);
        }

        private void HandleSwap(UIInventoryItem inventoryItem)
        {
            int index = listOfUIItems.IndexOf(inventoryItem);
            if (index == -1)
            {
                mouseFollower.Toggle(false);
                currentlyDraggedItemIndex = -1;
                return;
            }
            listOfUIItems[currentlyDraggedItemIndex].SetData(index == 0 ? image : image2, quantity);
            listOfUIItems[index].SetData(currentlyDraggedItemIndex == 0 ? image : image2, quantity);
            mouseFollower.Toggle(false);
            currentlyDraggedItemIndex = -1;
            
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
            _uiInventoryDescription.ResetDescription();
            listOfUIItems[0].SetData(image, quantity);
            listOfUIItems[1].SetData(image2, quantity);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
