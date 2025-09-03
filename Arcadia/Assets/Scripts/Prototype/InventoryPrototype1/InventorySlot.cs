using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using System.Collections;
using TMPro;

namespace Arcadia.Prototype.InventoryPrototype1
{
    public class InventorySlot : MonoBehaviour
    {
        private Item mItem; //아이템 인스턴스
        public Item Item
        {
            get
            {
                return mItem;
            }
        }

        [Header("드랍 가능한 타입 마스크")]
        [SerializeField] private ItemType mSlotMask;
        private int mItemCount;

        [Header("아이템 슬롯의 UI오브젝트")]
        [SerializeField] private Image mItemImage;
        [SerializeField] private Image mCooltimeImage;
        [SerializeField] private TextMeshProUGUI mTextCount;
        //아이템 이미지 투명도 조절
        private void SetColor(float _alpha)
        {
            Color color = mItemImage.color;
            color.a = _alpha;
            mItemImage.color = color;
        }

        public bool IsMask(Item item)
        {
            return ((int)item.Type & (int)mSlotMask) == 0 ? false : true;
        }

        public void AddItem(Item item, int count = 1)
        {
            mItem = item;
            mItemCount = count;
            mItemImage.sprite = mItem.Image;
            if (mItem.Type <= ItemType.Equipment_SHOES)
            {
                mTextCount.text = "";
            }
            else
            {
                mTextCount.text = mItemCount.ToString();
            }
            SetColor(1);
        }

        public void UpdateSlotCount(int count)
        {
            mItemCount += count;
            mTextCount.text = mItemCount.ToString();
            if (mItemCount <= 0)
            {
                ClearSlot();
            }
        }

        public void ClearSlot()
        {
            mItem = null;
            mItemCount = 0;
            mItemImage.sprite = null;
            SetColor(0);
            mTextCount.text = "";
        }
    }
}