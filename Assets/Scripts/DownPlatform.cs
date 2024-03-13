using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownPlatform : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed = 0;
    private bool isBoarded;
    void Start()
    {
        Physics2D.IgnoreLayerCollision(6, 6);
        Physics2D.IgnoreLayerCollision(6, 11);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.gameObject.transform.SetParent(transform);
            Rigidbody2D playerRb = col.gameObject.GetComponent<Rigidbody2D>();
            playerRb.interpolation = RigidbodyInterpolation2D.None;
            speed = 5f;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.gameObject.transform.SetParent(null);
            Rigidbody2D playerRb = col.gameObject.GetComponent<Rigidbody2D>();
            playerRb.interpolation = RigidbodyInterpolation2D.Interpolate;
            speed = 0f;
        }
    }

}
