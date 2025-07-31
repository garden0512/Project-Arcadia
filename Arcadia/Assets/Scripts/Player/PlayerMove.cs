using UnityEngine;
using UnityEngine.InputSystem;

namespace Arcadia.Player
{
    public class PlayerMove : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _inputValue;
        [SerializeField] private float _jumpForce;
        [SerializeField] private bool _isGrounded;
        
        private Rigidbody2D _rigidbody2D;
        private SpriteRenderer _spriteRenderer;
        public float inputValue => _inputValue;

        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void FixedUpdate()
        {
            _rigidbody2D.linearVelocityX = _inputValue * _speed;
        }

        private void LateUpdate()
        {
            //여기엔 캐릭터 애니메이션 들어갈거임
            if (_inputValue != 0)
            {
                _spriteRenderer.flipX = _inputValue < 0;
            }
        }

        private void OnMove(InputValue value)
        {
            _inputValue = value.Get<Vector2>().x;
        }
        
        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Ground"))
            {
                _isGrounded = true;
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.CompareTag("Ground"))
            {
                _isGrounded = false;
            }
        }

        private void OnJump()
        {
            if (_isGrounded)
            {
                _rigidbody2D.AddForceY(_jumpForce, ForceMode2D.Impulse);
            }
        }
    }
}
