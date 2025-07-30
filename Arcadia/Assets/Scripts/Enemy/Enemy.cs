using Arcadia.Player;
using UnityEngine;

namespace Arcadia.Enemy
{
    public class Enemy : MonoBehaviour
    {
        public string enemyName;
        public int maxHp;
        public int nowHp;
        public int attackDamage;
        public int attackSpeed;
        public Health player;

        private void SetEnemyStatus(string _enemyName, int _maxHp, int _attackDamage, int _attackSpeed)
        {
            enemyName = _enemyName;
            nowHp = _maxHp;
            maxHp = _maxHp;
            attackDamage = _attackDamage;
            attackSpeed = _attackSpeed;
        }

        private void Start()
        {
            if (name.Equals("Enemy1"))
            {
                SetEnemyStatus("Enemy1", 200, 5, 1);
            }
            //체력바 위치 잡는 메서드 있어야 함.
        }

        private void Update()
        {
            //hp바의 체력 채우고 비우는 기능이 들어가야 함.
        }

        private void OnTriggerEnter2D(Collider2D collider2)
        {
            if (collider2.CompareTag("Player"))
            {
                if (player.attacked)
                {
                    nowHp -= player.attackDamage;
                    Debug.Log(nowHp);
                    player.attacked = false;
                    if (nowHp <= 0)
                    {
                        Destroy(gameObject);
                    }
                }
            }
        }
    }
}
