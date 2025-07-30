using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Arcadia.UI.Inventory3
{
    public class InventoryUIController : MonoBehaviour
    {
        [SerializeField] private GameObject _inventory;
        private bool _isOpen = true;

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                _isOpen = !_isOpen;
                _inventory.SetActive(_isOpen);
            }
        }
    }
}