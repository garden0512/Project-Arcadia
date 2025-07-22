using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            
        }
        /// <summary>
        /// 모델에서의 변경상태를 뷰어에 제공
        /// </summary>
        public bool OnItemAdded(ItemSO itemSO, int quantity)
        {
            
        }
        /// <summary>
        /// 모델에서의 변경상태를 뷰어에 제공
        /// </summary>
        public bool OnItemRemoved(ItemSO itemSO, int quantity)
        {
            
        }
        /// <summary>
        /// 슬롯을 클릭했을 때의 동작 처리
        /// </summary>
        public void HandleClick()
        {
            
        }
        /// <summary>
        /// 슬롯의 변화를 뷰어에 알리는 역할
        /// </summary>
        public void NotifySlotChanged()
        {
            
        }
    }
}