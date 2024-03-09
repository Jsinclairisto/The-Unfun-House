using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float jumpForce;
    private float moveVelocity;
    public bool isTouchingGround, isInvert, facingRight, isJumping, isFlipped, flipBool, isDead;
    public Animator playerAnimator;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public TimeControl timeControl;
    public LayerMask groundLayer;
    private float jumpTimeCounter;
    private Transform originalParent;
    public float jumpTime;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //timeControl = GameObject.FindGameObjectWithTag("TimeControl");
        originalParent = transform.parent;
    }
    void FixedUpdate()
    {
        timeControl.TimeScale -= 0.0008f;
        rb.velocity = new Vector2(moveVelocity, rb.velocity.y);
    }
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
        moveVelocity = 0;
        float horizontalMove = Input.GetAxis("Horizontal");
        
        

        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)) && !isDead)
        {
            moveVelocity = -speed;
            //playerAnimator.SetFloat("speed", Mathf.Abs(horizontalMove));

        }
        if ((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) && !isDead)
        {
            moveVelocity = speed;
            if (isTouchingGround)
            {
                //playerAnimator.Play("PLAYER_RUN");
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && isTouchingGround == true && !isDead)
        {
            isJumping = true;
            jumpTimeCounter = jumpTime;
            if (isFlipped == true)
            {
                rb.velocity = Vector2.up * (-1) * jumpForce;
                Debug.Log("FLIPPED");
            }
            else if (isFlipped == false)
            {
                rb.velocity = Vector2.up * jumpForce;
            }
        }
        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if (jumpTimeCounter > 0)
            {
                if (isFlipped == true)
                {
                    rb.velocity = Vector2.up * (-1) * jumpForce;
                    Debug.Log("FLIPPED");
                }
                else if (isFlipped == false)
                {
                    rb.velocity = Vector2.up * jumpForce;
                }
                jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }

        Flip(horizontalMove);
        rb.velocity = new Vector2(moveVelocity, rb.velocity.y);
        if (!isTouchingGround)
        {
            playerAnimator.SetBool("IsJumping", true);
        }
        else 
        {
            playerAnimator.SetBool("IsJumping", false);
        }
        playerAnimator.SetFloat("Speed", Mathf.Abs(moveVelocity));

    }
    
    private void Flip(float horizontalMove)
    {
        if (horizontalMove > 0 && facingRight || horizontalMove < 0 && !facingRight && !isDead)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("EnemyDeathCollide"))
        {
            Die();
            Debug.Log("Hitting");
            //Destroy(this.gameObject);
            //playerAnimator.SetBool("IsDead", true);
            //isDead = true;
        }
        if (col.CompareTag("DeathCollide")) 
        {
            Die();
            //Destroy(this.gameObject);
            //playerAnimator.SetBool("IsDead", true);
            //isDead = true;
        }

        if (col.CompareTag("TimePowerUp")) 
        {
            timeControl.TimeScale = 1;
        }
    }

    private void Die() 
    {
        isDead = true;
        rb.bodyType = RigidbodyType2D.Static;
        playerAnimator.Play("PLAYER_DEATH");
    }

}
