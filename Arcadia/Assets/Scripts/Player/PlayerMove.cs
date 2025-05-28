using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float inputValueX;
    [SerializeField] float inputValueY;
    [SerializeField] float pushForce;
    private float lastImageXpos;
    public float distanceBetweenImages;
    private float direction;
    

    private Rigidbody2D body;
    // private PlayerAnimationController animationController;
    // private PlayerEntity playerEntity;

    Vector2 lastMoveDirection;
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        // animationController = GetComponent<PlayerAnimationController>();
        // lastMoveDirection = Vector2.down;
    }

    // public void Initialize(PlayerEntity entityPlayer)
    // {
    //     playerEntity = entityPlayer;
    // }

    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            body.linearVelocity = new Vector2(0, 0);
            direction = transform.localScale.x > 0 ? 1f : -1f;
            body.AddForce(new Vector2(pushForce*direction, 0), ForceMode2D.Impulse);
            if (Mathf.Abs(transform.position.x - lastImageXpos) > distanceBetweenImages)
            {
                PlayerAfterImagePool.Instance.GetFromPool();
                lastImageXpos = transform.position.x;
            }
        }
        // if (playerEntity != null && playerEntity.IsTalking)
        // {
        //     inputValueX = 0;
        //     inputValueY = 0;
        // }
        if (inputValueX != 0 && inputValueY != 0)
        {
            inputValueY = 0;
        }
        body.linearVelocityX = inputValueX * speed;
        // body.linearVelocityY = inputValueY * speed;

        Vector2 moveVector = new Vector2(inputValueX,0f);

        if (moveVector != Vector2.zero)
        {
            lastMoveDirection = moveVector.normalized;
        }

        // animationController.AnimationUpdate(moveVector, lastMoveDirection);
    }

    private void OnMove(InputValue value)
    {
        inputValueX = value.Get<Vector2>().x;
        // inputValueY = value.Get<Vector2>().y;
    }
}