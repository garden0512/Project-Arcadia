using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

namespace Arcadia.Prototype.InventoryPrototype1
{
    public class UIInventoryPage : MonoBehaviour
    {
        [SerializeField] private UIInventoryItem _uiInventoryItem;
        [SerializeField] private RectTransform _inventoryPanelTransform;
        [SerializeField] private UIInventoryDescription _uiInventoryDescription;
        private List<UIInventoryItem> listOfUIItems = new List<UIInventoryItem>();
        public Sprite image;
        public int quantity;
        public string title, description;

        private void Awake()
        {
            Hide();
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

        private void HandleBeginDrag(UIInventoryItem obj)
        {
            
        }

        private void HandleSwap(UIInventoryItem obj)
        {
            
        }

        private void HandleEndDrag(UIInventoryItem obj)
        {
            
        }

        private void HandleShowItemActions(UIInventoryItem obj)
        {
            
        }

        public void Show()
        {
            gameObject.SetActive(true);
            _uiInventoryDescription.ResetDescription();
            listOfUIItems[0].SetData(image, quantity);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
