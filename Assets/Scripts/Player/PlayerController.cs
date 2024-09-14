using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask groundMask;

    private int extraJumps;
    public int extraJumpsValue;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    public bool onPlatform;
    public Rigidbody2D platformRb;

    GameController gameController; 

    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        gameController = FindObjectOfType<GameController>();
    }

    void FixedUpdate()
    {
        moveInput = Input.GetAxis("Horizontal");
        float targetSpeed = moveInput * speed;
        if (onPlatform)
        {
            rb.velocity = new Vector2(targetSpeed + platformRb.velocity.x, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(targetSpeed, rb.velocity.y);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundMask);

        //  Flip player when moving left/right
        if (horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (isGrounded == true )
        {
            extraJumps = extraJumpsValue;
        }

        if(Input.GetKeyDown("space") && extraJumps > 0)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        } else if(Input.GetKeyDown("space") && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetKey("space") && isJumping == true)
        {
            if(jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetKeyUp("space"))
        {
            isJumping = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy")) //
        {
            // Destroy the enemy when the player collides from above
            Vector2 contactPoint = other.ClosestPoint(transform.position);
            if (contactPoint.y < transform.position.y)
            {
                Destroy(other.gameObject);
            }
        }
    }

    public void AddExtraJump()
    {
        extraJumps++;
    }
}