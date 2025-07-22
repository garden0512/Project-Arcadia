using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Arcadia.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField]private Animator _animator;
        [SerializeField]private List<SlashEffect> _slashEffects;
        public int hasAttackCount = Animator.StringToHash("AttackCount");
        private bool _effectPlayed;
        private string _lateState = "";
        private string currentState = "";
        
        private void Start()
        {
            TryGetComponent(out _animator);
            DisableSlash();
        }
        
        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                _animator.SetTrigger("isAttacking");
            }
            AnimatorStateInfo stateInfo = _animator.GetCurrentAnimatorStateInfo(0);
            //현재 애니메이션 이름 감지
            if (stateInfo.IsName("Attack_1"))
            {
                currentState = "Attack1";
            }
            else if (stateInfo.IsName("Attack_2"))
            {
                currentState = "Attack2";
            }
            else if (stateInfo.IsName("Attack_3"))
            {
                currentState = "Attack3";
            }
            //상태 바뀔 시 효과 다시 재생되도록 설정
            if (currentState != _lateState)
            {
                _lateState = currentState;
                _effectPlayed = false;
            }
            //이펙트 실행이 안 되었으나 공격상태일 때
            if(!_effectPlayed && currentState != "")
            {
                int effectIndex = currentState switch
                {
                    "Attack1" => 0,
                    "Attack2" =>1,
                    "Attack3" =>2,
                    _ => -1,
                };
                if (effectIndex >= 0 && effectIndex < _slashEffects.Count)
                {
                    StartCoroutine(PlaySlashEffect(effectIndex));
                    _effectPlayed = true;
                }
            }
        }

        private IEnumerator PlaySlashEffect(int index)
        {
            yield return new WaitForSeconds(_slashEffects[index].delay);
            _slashEffects[index]._effect.SetActive(true);
            yield return new WaitForSeconds(1f);
            _slashEffects[index]._effect.SetActive(false);
        }

        private void DisableSlash()
        {
            for (int i = 0; i < _slashEffects.Count; i++)
            {
                _slashEffects[i]._effect.SetActive(false);
            }
        }
        public int AttackCount
        {
            get => _animator.GetInteger(hasAttackCount);
            set => _animator.SetInteger(hasAttackCount, value);
        }
    }

    [System.Serializable]
    public class SlashEffect
    {
        public GameObject _effect;
        public float delay;
    }
}
