using Arcadia.UI.Dialogue;
using UnityEngine;

namespace Arcadia.Player
{
    public class callDilaogue : MonoBehaviour
    {
        public DialogueManager dialogueManager;
        private Vector3 dirVec;
        public PlayerMove _playerMove;
        private Rigidbody2D _rigidbody2D;
        public GameObject scanObject;
        
        private void Awake()
        {
            _rigidbody2D = GetComponent<Rigidbody2D>();
        }

        private void Update()
        {
            if (_playerMove.inputValue > 0)
            {
                dirVec = Vector3.right;
            }
            else if (_playerMove.inputValue < 0)
            {
                dirVec = Vector3.left;
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                dialogueManager.Action(scanObject);
            }
        }

        private void FixedUpdate()
        {
            Debug.DrawRay(_rigidbody2D.position, dirVec * 0.7f, Color.green);
            RaycastHit2D rayHit = Physics2D.Raycast(_rigidbody2D.position, dirVec, 0.7f, LayerMask.GetMask("Object"));
            if (rayHit.collider != null)
            {
                scanObject = rayHit.collider.gameObject;
            }
            else
            {
                scanObject = null;
            }
        }
    }
}