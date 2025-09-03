using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Arcadia.Prototype.InventoryPrototype1
{
    public class UIInventoryPage : MonoBehaviour
    {
        [SerializeField] private UIInventoryItem _uiInventoryItem;
        [SerializeField] private RectTransform _inventoryPanelTransform;
        private List<UIInventoryItem> listOfUIItems = new List<UIInventoryItem>();

        public void InitializeInventoryUI(int inventorySize)
        {
            for (int i = 0; i < inventorySize; i++)
            {
                UIInventoryItem uiInventoryItem = Instantiate(_uiInventoryItem, Vector3.zero, Quaternion.identity);
                uiInventoryItem.transform.SetParent(_inventoryPanelTransform);
                listOfUIItems.Add(uiInventoryItem);
            }
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
