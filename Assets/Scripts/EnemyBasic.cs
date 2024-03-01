using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBasic : MonoBehaviour
{
    public GameObject point1, point2;
    private Rigidbody2D rb;
    private Transform currentPosition;
    public float speed;
    void Start()
    {
        rb = GetComponent <Rigidbody2D>();
        currentPosition = point2.transform;
    }

    

    void Update()
    {
        
        Vector2 point = currentPosition.position - transform.position;
        if (currentPosition == point2.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else 
        {
            rb.velocity = new Vector2(-speed, 0);
        }
        if (Vector2.Distance(transform.position, currentPosition.position) < 0.5f && currentPosition == point2.transform) 
        {
            flip();
            currentPosition = point1.transform;
        }
        if (Vector2.Distance(transform.position, currentPosition.position) < 0.5f && currentPosition == point1.transform)
        {
            flip();
            currentPosition = point2.transform;
        }

    }
    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
}
