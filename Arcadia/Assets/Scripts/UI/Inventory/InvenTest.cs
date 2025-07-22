using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arcadia.UI.Inventory
{
    public class InvenTest : MonoBehaviour
    {
        [Header("인벤 메인")]
        [SerializeField] private InventoryMain _inventoryMain;
        
        [Header("획득 아이템")]
        [SerializeField] private Item _hpPotion, _Trash;

        private void OnGUI()
        {
            if (GUI.Button(new Rect(20, 20, 300, 40), "체력포션 얻기"))
            {
                _inventoryMain.AcquireItem(_hpPotion);
            }

            if (GUI.Button(new Rect(400, 20, 300, 40), "쓰레기 얻기"))
            {
                _inventoryMain.AcquireItem(_Trash);
            }
        }
    }
}
