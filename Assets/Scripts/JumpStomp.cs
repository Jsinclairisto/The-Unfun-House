using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpStomp : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float bounce;

    public Rigidbody2D rb2D;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Enemy")) 
        {
            Destroy(col.gameObject);
            rb2D.velocity = new Vector2(rb2D.velocity.x, bounce);
        }
    }
}
