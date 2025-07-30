using System;
using UnityEngine;
using TMPro;

namespace Arcadia.Player
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _hp;
        [SerializeField] private int _maxHp;
        private int _currentHp;
        private bool isDead => _currentHp <= 0;
        
        public int CurrentHp => _currentHp;
        public int MaxHp => _maxHp;

        private void Start()
        {
            _currentHp = _maxHp;
        }

        private void TakeDamage(int damage)
        {
            _currentHp -= damage;
            Debug.Log($"받은 피해량 : {damage}, 체력 잔량 : {_currentHp}");
            if (isDead)
            {
                Die();
            }
        }

        private void Die()
        {
            Debug.Log("플레이어 죽음");
        }
    }
}