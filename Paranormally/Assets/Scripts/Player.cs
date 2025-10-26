using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D myCollider;
    Animator anim;
    AudioSource myAudio;
    Vector2 moveDirection;
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float maxVelocity;
    [SerializeField] private float dashForce;
    [SerializeField] private float antiGravityBoostForce;
    public LayerMask groundLayer;
    bool canJump;
    bool isFacingRight = true;

    bool canUseAGB = false;
    bool canUseDash = false;

    public bool canMove = true;
    SFXManager sfx;
    [SerializeField] AudioClip jumpSound;
    [SerializeField] AudioClip dashSound;
    [SerializeField] AudioClip upDashSound;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        myCollider = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        myAudio = GetComponent<AudioSource>();
        sfx = FindAnyObjectByType<SFXManager>();
    }

    private void Update()
    {
        if(canMove)
        {
            FlipSprite();
            if (myCollider.IsTouchingLayers(groundLayer))
            {
                canJump = true;
                canUseAGB = true;
                canUseDash = true;
            }
            else
            {
                canJump = false;
            }
            if (Keyboard.current.cKey.wasPressedThisFrame && canUseDash)
            {
                Dash();
                canUseDash = false;
            }
            if (Keyboard.current.zKey.wasPressedThisFrame && canUseAGB)
            {
                AntiGravityBoost();
                canUseAGB = false;
            }
        }
        
    }


    void OnMove(InputValue value)
    {
        moveDirection = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if(value.isPressed && canJump && canMove)
        {
            sfx.PlayAnyAudio(jumpSound);
            anim.SetTrigger("jump");
            rb.linearVelocityY += jumpSpeed;
        }
        
    }
    private void FixedUpdate()
    {
        if(canMove)
        {
            Walk();
        }
        
    }

    void Walk()
    {
        if(!canJump)
        {
            return;
        }
        Vector2 playerVelocity = new Vector2(moveDirection.x * speed * Time.fixedDeltaTime, 0f);
        rb.linearVelocity += playerVelocity;
        if(Mathf.Abs(moveDirection.x)> 0f)
        {
            anim.SetBool("isWalking", true);
            myAudio.enabled = true;
        }
        else
        {
            anim.SetBool("isWalking", false);
            myAudio.enabled = false;
        }
        if (rb.linearVelocityX > maxVelocity)
        {
            rb.linearVelocityX = maxVelocity;
        }
        else if (rb.linearVelocityX < -maxVelocity)
        {
            rb.linearVelocityX = -maxVelocity;
        }
    }

    void FlipSprite()
    {
        if (moveDirection.x < 0 && isFacingRight)
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
            isFacingRight = false;
        }
        if (moveDirection.x > 0 && !isFacingRight)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            isFacingRight = true;
        }
    }

    void Dash()
    {
        sfx.PlayAnyAudio(dashSound);
        anim.SetTrigger("dash");
        if(isFacingRight)
        {
            rb.AddForceX(dashForce, mode: ForceMode2D.Impulse);
        }
        else
        {
            rb.AddForceX(-dashForce, mode: ForceMode2D.Impulse);
        }
    }

    void AntiGravityBoost()
    {
        sfx.PlayAnyAudio(upDashSound);
        anim.SetTrigger("dash");
        rb.AddForceY(antiGravityBoostForce, mode: ForceMode2D.Impulse);
    }
}
