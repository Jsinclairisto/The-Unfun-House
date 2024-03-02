using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityInverter : MonoBehaviour
{
    public PlayerMovement playerBool;
    private GameObject player;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        player.GetComponent<Rigidbody2D>();
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && !playerBool.isFlipped)
        {
            player.GetComponent<Rigidbody2D>().gravityScale = -5;
            if (playerBool.facingRight)
            {
                player.transform.localScale = new Vector3(-1f, -1f);
            }
            else
            {
                player.transform.localScale = new Vector3(1f, -1f);
            }
            playerBool.isFlipped = true;
            Destroy(this.gameObject);
        }
        else 
        {
            player.GetComponent<Rigidbody2D>().gravityScale = 5;
            if (playerBool.facingRight)
            {
                player.transform.localScale = new Vector3(-1f, 1f);
            }
            else
            {
                player.transform.localScale = new Vector3(1f, -1f);
            }
            playerBool.isFlipped = false;
            Destroy(this.gameObject);
        }
    }
}
