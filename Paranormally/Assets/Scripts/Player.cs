using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    CapsuleCollider2D myCollider;
    Vector2 moveDirection;
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float maxVelocity;
    public LayerMask groundLayer;
    bool canJump;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<CapsuleCollider2D>();
    }

    private void Update()
    {
        if(myCollider.IsTouchingLayers(groundLayer))
        {
            canJump = true;
        }
        else
        {
            canJump = false;
        }
    }


    void OnMove(InputValue value)
    {
        moveDirection = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if(value.isPressed && canJump)
        {
            rb.linearVelocityY += jumpSpeed;
        }
        
    }
    private void FixedUpdate()
    {
        Walk();
    }

    void Walk()
    {
        if(!canJump)
        {
            return;
        }
        Vector2 playerVelocity = new Vector2(moveDirection.x * speed * Time.fixedDeltaTime, 0f);
        rb.linearVelocity += playerVelocity;
        Mathf.Clamp(Mathf.Abs(rb.linearVelocityX),0,maxVelocity);
    }
}
