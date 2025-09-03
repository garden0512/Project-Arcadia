using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arcadia.Prototype.InventoryPrototype1
{
    public class UIInventoryPage : MonoBehaviour
    {
        [SerializeField] private UIInventoryItem _uiInventoryItem;
        [SerializeField] private RectTransform _inventoryPanelTransform;
        [SerializeField] private UIInventoryDescription _uiInventoryDescription;
        private List<UIInventoryItem> listOfUIItems = new List<UIInventoryItem>();

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
            Debug.Log(obj.name);
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
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
