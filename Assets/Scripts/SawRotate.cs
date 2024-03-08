using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawRotate : MonoBehaviour
{
    [SerializeField] private float anglePerSecond;
    void Update()
    {
        Vector3 rotation = transform.localEulerAngles;
        rotation.z += Time.deltaTime * anglePerSecond;
        transform.localEulerAngles = rotation;
    }
}
