using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Arcadia.UI.Inventory4;

namespace Arcadia.Prototype.InventoryPrototype1
{
    public class MouseFollower : MonoBehaviour
    {
        [SerializeField] private Canvas _canvas;
        [SerializeField] private Camera mainCam;
        [SerializeField] private UIInventoryItem _uiInventoryItem;

        public void Awake()
        {
            _canvas = transform.root.GetComponent<Canvas>();
            mainCam = Camera.main;
            _uiInventoryItem = GetComponentInChildren<UIInventoryItem>();
        }

        public void SetData(Sprite sprite, int quantity)
        {
            _uiInventoryItem.SetData(sprite, quantity);
        }

        void Update()
        {
            Vector2 position; 
            RectTransformUtility.ScreenPointToLocalPointInRectangle((RectTransform)_canvas.transform,
                Input.mousePosition, _canvas.worldCamera, out position);
            transform.position = _canvas.transform.TransformPoint(position);
        }

        public void Toggle(bool val)
        {
            Debug.Log($"아이템이 토글되었습니다 : {val}");
            gameObject.SetActive(val);
        }
    }
}