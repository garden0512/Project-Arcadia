using UnityEngine;

namespace Arcadia.Player
{
    public class Health : MonoBehaviour
    {
        public int maxHp;
        public int nowHp;
        public int attackDamage;
        public float attackSpeed;
        public bool attacked = false;
        //public Image nowHPBar; //추후 HP바가 추가된다면 사용

        private void Start()
        {
            maxHp = 100;
            nowHp = maxHp;
            attackDamage = 20;
            SetAttackSpeed(1.5f);
        }

        // private void Update()
        // {
        //     if (Input.GetMouseButtonDown(0))
        //     {
        //         AttackTrue();
        //     }
        //     else
        //     {
        //         AttackFalse();
        //     }
        // }
        private void AttackTrue()
        {
            attacked = true;
        }

        private void AttackFalse()
        {
            attacked = false;
        }

        private void SetAttackSpeed(float speed)
        {
            attackSpeed = speed;
        }
    }
}