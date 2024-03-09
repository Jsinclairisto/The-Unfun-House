using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollide : MonoBehaviour
{
    // Start is called before the first frame update
    public PlayerMovement player;
    void Start()
    {
        Physics2D.IgnoreLayerCollision(11, 6);
        Physics2D.IgnoreLayerCollision(11, 10);
        Physics2D.IgnoreLayerCollision(11, 9);
    }
    private void Update()
    {
        if (player.isDead == true) 
        {
            transform.gameObject.tag = "Emptytag";
        }
    }
}
