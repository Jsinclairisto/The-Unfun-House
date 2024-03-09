using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Player") 
        {
            col.gameObject.transform.SetParent(transform);
            Rigidbody2D playerRb = col.gameObject.GetComponent<Rigidbody2D>();
            playerRb.interpolation = RigidbodyInterpolation2D.None;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.gameObject.name == "Player") 
        {
            col.gameObject.transform.SetParent(null);
            Rigidbody2D playerRb = col.gameObject.GetComponent<Rigidbody2D>();
            playerRb.interpolation = RigidbodyInterpolation2D.Interpolate;
        }
    }
}