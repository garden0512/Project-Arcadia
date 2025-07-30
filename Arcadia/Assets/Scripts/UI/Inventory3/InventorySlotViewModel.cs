using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Arcadia.UI.Inventory3
{
    public class InventorySlotViewModel : MonoBehaviour
    {
        private InventorySlotModel _inventorySlotModel;
        public string ItemName;
        public Sprite ItemImage;
        public int Quantity;
        public bool IsEmpty;
        public event Action OnSlotChanged;

        /// <summary>
        /// 뷰어와 모델들 중개인 역할
        /// </summary>
        public void Bind(InventorySlotModel inventorySlotModel)
        {
            _inventorySlotModel = inventorySlotModel;
            UpdateFromModel();
        }

        /// <summary>
        /// 모델에서의 변경상태를 뷰어에 제공
        /// </summary>
        public bool OnItemAdded(ItemSO itemSO, int quantity)
        {
            if (_inventorySlotModel == null)
            {
                Debug.LogError("InventorySlotViewModel::OnItemAdded: 인벤토리슬롯 모델이 비어있습니다.");
                return false;
            }

            _inventorySlotModel.AddItem(itemSO, quantity);
            UpdateFromModel();
            NotifySlotChanged();
            return true;
        }

        /// <summary>
        /// 모델에서의 변경상태를 뷰어에 제공
        /// </summary>
        public bool OnItemRemoved(ItemSO itemSO, int quantity)
        {
            if (_inventorySlotModel == null)
            {
                Debug.LogError("InventorySlotViewModel::OnItemAdded: 인벤토리슬롯 모델이 비어있습니다.");
                return false;
            }

            _inventorySlotModel.SubtractItem(itemSO, quantity);
            UpdateFromModel();
            NotifySlotChanged();
            return true;
        }

        /// <summary>
        /// 슬롯을 클릭했을 때의 동작 처리
        /// </summary>
        public void HandleClick()
        {
            if (_inventorySlotModel == null)
            {
                return;
            }

            if (_inventorySlotModel.IsEmptySlot())
            {
                Debug.Log("빈 슬롯");
            }
            else
            {
                Debug.Log(
                    $"아이템 클릭됨 : 아이템 타입 : {_inventorySlotModel.ItemSO.ItemType}, 아이템 색 : {_inventorySlotModel.ItemSO.ItemColor}");
            }
        }

        /// <summary>
        /// 슬롯의 변화를 뷰어에 알리는 역할
        /// </summary>
        public void NotifySlotChanged()
        {
            OnSlotChanged?.Invoke();
        }

        /// <summary>
        /// 내부 상태 갱신 유틸리티 메서드
        /// </summary>
        public void UpdateFromModel()
        {
            if (_inventorySlotModel == null)
            {
                ItemName = "";
                ItemImage = null;
                Quantity = 0;
                IsEmpty = true;
                return;
            }

            ItemSO itemSO = _inventorySlotModel.ItemSO;
            if (itemSO != null)
            {
                ItemName = itemSO.name;
                ItemImage = itemSO.ItemImage;
                Quantity = _inventorySlotModel.Quantity();
                IsEmpty = _inventorySlotModel.IsEmptySlot();
            }
            else
            {
                ItemName = "";
                ItemImage = null;
                Quantity = 0;
                IsEmpty = true;
            }
        }
    }
}