using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatformSpike : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            col.gameObject.transform.SetParent(transform);
            Rigidbody2D playerRb = col.gameObject.GetComponent<Rigidbody2D>();
            playerRb.interpolation = RigidbodyInterpolation2D.None;
        }
    }

    private void OnCollisionExit2D(Collision2D col)
    {
        if (col.gameObject.name == "Player")
        {
            col.gameObject.transform.SetParent(null);
            Rigidbody2D playerRb = col.gameObject.GetComponent<Rigidbody2D>();
            playerRb.interpolation = RigidbodyInterpolation2D.Interpolate;
        }
    }
}
