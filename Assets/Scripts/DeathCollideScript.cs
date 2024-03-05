using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCollide : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(11, 6);
        Physics2D.IgnoreLayerCollision(11, 10);
        Physics2D.IgnoreLayerCollision(11, 9);
    }
}
