using UnityEngine;
using UnityEngine.UI;

namespace Arcadia.UI.Inventory
{
    public class DragSlot : MonoBehaviour
    {
        [HideInInspector] public InventorySlot CurrentSlot;
        [HideInInspector] public bool IsShiftMode;
        public static DragSlot instance;
        [SerializeField] private Image _itemImage;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            SetColor(0);
        }
        public void DragSetImage(Image image)
        {
            _itemImage.sprite = image.sprite;
            SetColor(1);
        }

        public void SetColor(float alpha)
        {
            Color color = _itemImage.color;
            color.a = alpha;
            _itemImage.color = color;
        }
    }
}