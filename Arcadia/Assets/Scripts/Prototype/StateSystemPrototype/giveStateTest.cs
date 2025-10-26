using UnityEngine;

namespace Arcadia.Prototype.StateSystemPrototype
{
    public class giveStateTest : MonoBehaviour
    {
        [Header("플레이어 이동 관련 상태")]
        public bool isWalking = false;
        public bool isJumping = false;
        public bool isSitting = false;
        public bool isDashing = false;
        public bool isIdle = false;

        [Header("플레이어 공격 관련 상태")]
        public bool isAttacking = false;
        public bool isParrying = false;
        public bool isSpecialAttacking = false;
        public bool isHitting = false;
        public bool isKnockbacked = false;

        [Header("플레이어 기타 상태")]
        public bool isInventoryOpened = false;
        public bool isOptionOpened = false;
        public bool isTalking = false;

        public void OnEnable()
        {
            Debug.Log("----------< 키 설명 >----------");
            Debug.Log("----------< 플레이어 이동 관련 상태 >----------");
            Debug.Log("Default : isIdle\nW : isWalking\nJ : isJumping\nCtrl : isSitting\nShift : isDashing");
            Debug.Log("----------< 플레이어 공격 관련 상태 >----------");
            Debug.Log("Left Mouse : isAttacking\nP : isParrying\nRight Mouse : isSpecialAttacking\nH : isHitting\nK : isKnockbacked");
            Debug.Log("----------< 플레이어 기타 상태 >----------");
            Debug.Log("I : isInventoryOpened\nESC : isOptionOpened\nT : isTalking");
            Debug.Log("------------------------------");
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                isWalking = true;
                Debug.Log($"isWalking: {isWalking}");
            }
        }
    }
}