using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private BoxCollider2D coll;
    private Animator animator;
    private SpriteRenderer rbSprite;

    [SerializeField] private LayerMask jumpableGround;

    private float dirX = 0f;
    [SerializeField] private float speedX = 7f;
    [SerializeField] private float jumpForce = 14f;
    private enum MovementSate { idle, running, jumping, falling }

    [SerializeField] private AudioSource jumpSound;

    // Start is called before the first frame update
    private void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        rbSprite = GetComponent<SpriteRenderer>();
        coll = GetComponent<BoxCollider2D>();  
        
    }

    // Update is called once per frame
    private void Update()
    {
        dirX = Input.GetAxisRaw("Horizontal");

        rb2D.velocity = new Vector2 (speedX * dirX, rb2D.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            jumpSound.Play();
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
        }

        UpdateAnimationState();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }

    private void UpdateAnimationState()
    {
        MovementSate state;

        if (dirX > 0f)
        {
            state = MovementSate.running;
            rbSprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementSate.running;
            rbSprite.flipX = true;
        }
        else
        {
            state = MovementSate.idle;
        }

        if(rb2D.velocity.y > .1f)
        {
            state = MovementSate.jumping;
        }
        else if (rb2D.velocity.y < -.1f)
        {
            state = MovementSate.falling;
        }
        animator.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround); 
    }
}
