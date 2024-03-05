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
    public bool isTouchingGround, isInvert, facingRight, isJumping, isFlipped, flipBool;
    public Animator playerAnimator;
    public Transform groundCheckPoint;
    public float groundCheckRadius;
    public TimeControl timeControl;
    public LayerMask groundLayer;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //timeControl = GameObject.FindGameObjectWithTag("TimeControl");
    }
    void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheckPoint.position, groundCheckRadius, groundLayer);
        moveVelocity = 0;
        float horizontalMove = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveVelocity, rb.velocity.y);
        timeControl.TimeScale -= 0.00006f;

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            moveVelocity = -speed;
            //playerAnimator.SetFloat("speed", Mathf.Abs(horizontalMove));

        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            moveVelocity = speed;
            if (isTouchingGround)
            {
                //playerAnimator.Play("PLAYER_RUN");
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && isTouchingGround == true)
        {
            isJumping = true;
            //jumpTimeCounter = jumpTime;
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
        if (horizontalMove > 0 && facingRight || horizontalMove < 0 && !facingRight)
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
            Debug.Log("Hitting");
            Destroy(this.gameObject);
        }
        if (col.CompareTag("TimePowerUp")) 
        {
            timeControl.TimeScale = 1;
        }
    }

}
