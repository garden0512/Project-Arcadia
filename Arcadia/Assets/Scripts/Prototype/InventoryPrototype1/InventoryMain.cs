using UnityEditor.Build.Content;
using UnityEngine;

namespace Arcadia.Prototype.InventoryPrototype1
{
    public class InventoryMain : InventoryBase
    {
        public static bool IsInventoryActive = false;

        new void Awake()
        {
            base.Awake();
        }

        void Update()
        {
            TryOpenInventory();
        }
        /// <summary>
        /// 인벤토리를 I키를 눌러서 열거나 닫음
        /// </summary>
        private void TryOpenInventory()
        {
            //옵션이 켜진 경우 비활성화
            if (GameManager.IsOptionActive)
            {
                return;
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                if (!IsInventoryActive)
                {
                    OpenInventory();
                }
                else
                {
                    CloseInventory();
                }
            }
        }
        /// <summary>
        /// 인벤토리 열기
        /// </summary>
        private void OpenInventory()
        {
            mInventoryBase.SetActive(true);
            IsInventoryActive = true;
            UtilityManager.UnlockCursor();
        }
        /// <summary>
        /// 인벤토리 닫기
        /// </summary>
        public void CloseInventory()
        {
            mInventoryBase.SetActive(false);
            IsInventoryActive = false;
            UtilityManager.TryLOckCursor;
        }
    }
}