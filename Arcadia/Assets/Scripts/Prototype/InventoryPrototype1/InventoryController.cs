using UnityEngine;

namespace Arcadia.Prototype.InventoryPrototype1
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private UIInventoryPage _uiInventoryPageWithoutFrameTitle;
        [SerializeField] private UIInventoryPage _uiInventoryPageWithFrameTitle;
        public int inventorySize = 10;

        private void Start()
        {
            _uiInventoryPageWithoutFrameTitle.InitializeInventoryUI(inventorySize);
            _uiInventoryPageWithFrameTitle.InitializeInventoryUI(inventorySize);
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                if (_uiInventoryPageWithoutFrameTitle.isActiveAndEnabled == false)
                {
                    _uiInventoryPageWithoutFrameTitle.Show();
                }
                else
                {
                    _uiInventoryPageWithoutFrameTitle.Hide();
                }
            }
        }
    }
}