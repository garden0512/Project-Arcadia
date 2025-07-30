using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.EventSystems;

namespace Arcadia.UI.Inventory
{
    /// <summary>
    /// 슬롯 "한 칸"만 담당하는 놈
    /// </summary>
    public class InventorySlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler, IDropHandler
    {
        private Item _item;

        public Item Item
        {
            get
            {
                return _item;
            }
        }
        
        [Header("해당 슬롯에 들어올 수 있는 타입 마스크")]
        [SerializeField] private ItemType _slotMask;
        private int _itemCount;

        [Header("슬롯에 있는 아이템 UI 오브젝트")]
        [SerializeField] private Image _itemImage;
        [SerializeField] private Image _cooltimeImage;
        [SerializeField] private TextMeshProUGUI _textCount;

        private void SetColor(float _alpha)
        {
            Color color = _itemImage.color;
            color.a = _alpha;
            _itemImage.color = color;
        }

        public bool IsMask(Item item)
        {
            return ((int) item.ItemType & (int)_slotMask) == 0 ? false : true;
        }

        // 새로운 아이템 슬롯 추가
        public void AddItem(Item item, int count = 1)
        {
            _item = item;
            _itemCount = count;
            _itemImage.sprite = _item.Image;
            if (_item.ItemType <= ItemType.Dummy)
            {
                _textCount.text = "";
            }
            else
            {
                _textCount.text = _itemCount.ToString();
            }
            SetColor(1);
        }
        
        // 아이템 개수 업데이트
        public void UpdateSlotCount(int count)
        {
            _itemCount += count;
            _textCount.text = _itemCount.ToString();
            if (_item.ItemType <= 0)
            {
                ClearSlot();
            }
        }
        
        //슬롯 삭제
        public void ClearSlot()
        {
            _item = null;
            _itemCount = 0;
            _itemImage.sprite = null;
            SetColor(0);
            _textCount.text = "";
        }
        
        //마우스 드래그 시작 오버라이드
        public void OnBeginDrag(PointerEventData eventData)
        {
            if (_item != null)
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    DragSlot.instance.IsShiftMode = true;
                    Debug.Log("쉬프트 누름");
                }
            }
            else
            {
                DragSlot.instance.IsShiftMode = false;
                Debug.Log("쉬프트 안 누름");
            }
            DragSlot.instance.CurrentSlot = this;
            DragSlot.instance.DragSetImage(_itemImage);
            DragSlot.instance.transform.position = eventData.position;
        }
        
        // 마우스 드래그 중 매 프레임마다 호출
        public void OnDrag(PointerEventData eventData)
        {
            if (_item != null)
            {
                DragSlot.instance.transform.position = eventData.position;
            }
        }
        
        // 마우스 드래그 종료 오버라이드
        public void OnEndDrag(PointerEventData eventData)
        {
            DragSlot.instance.SetColor(0);
            Debug.Log("드래그 끝");
            DragSlot.instance.CurrentSlot = null;
        }
        
        // 해당 슬롯에 마우스드롭 되었을 때 발생
        public void OnDrop(PointerEventData eventData)
        {
            if (DragSlot.instance.IsShiftMode && _item != null)
            {
                return;
            }

            if (!IsMask(DragSlot.instance.CurrentSlot.Item))
            {
                return;
            }

            if (_item != null && !DragSlot.instance.CurrentSlot.IsMask(_item))
            {
                return;
            }

            ChangeSlot();
        }
        
        // 아이템 바꾸기
        private void ChangeSlot()
        {
            if (DragSlot.instance.CurrentSlot.Item.ItemType >= ItemType.Dummy)
            {
                if (_item != null && _item.ItemID == DragSlot.instance.CurrentSlot.Item.ItemID)
                {
                    int changeSlotCount;
                    if (DragSlot.instance.IsShiftMode)
                    {
                        changeSlotCount = (int)(DragSlot.instance.CurrentSlot._itemCount * 0.5f);
                    }
                    else
                    {
                        changeSlotCount = DragSlot.instance.CurrentSlot._itemCount;
                    }
                    UpdateSlotCount(changeSlotCount);
                    DragSlot.instance.CurrentSlot.UpdateSlotCount(-changeSlotCount);
                    return;
                }

                if (DragSlot.instance.IsShiftMode)
                {
                    int changeSlotCount = (int)(DragSlot.instance.CurrentSlot._itemCount * 0.5f);
                    if (changeSlotCount == 0)
                    {
                        AddItem(DragSlot.instance.CurrentSlot.Item, 1);
                        DragSlot.instance.CurrentSlot.ClearSlot();
                        return;
                    }
                    AddItem(DragSlot.instance.CurrentSlot.Item, changeSlotCount);
                    DragSlot.instance.CurrentSlot.UpdateSlotCount(-changeSlotCount);
                    return;
                }
            }
            Item tempItem = _item;
            int tempItemCount = _itemCount;
            AddItem(DragSlot.instance.CurrentSlot._item, DragSlot.instance.CurrentSlot._itemCount);
            if (tempItem != null)
            {
                DragSlot.instance.CurrentSlot.AddItem(tempItem, tempItemCount);
            }
            else
            {
                DragSlot.instance.CurrentSlot.ClearSlot();
            }
        }
    }
}
