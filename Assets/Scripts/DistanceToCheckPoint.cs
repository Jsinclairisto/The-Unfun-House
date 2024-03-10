using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceToCheckPoint : MonoBehaviour
{

    [SerializeField]
    private Transform checkPoint;

    [SerializeField]
    private Text distanceText;

    private float distance;

    void Update()
    {
        distance = (transform.position.y - checkPoint.transform.position.y);
        distanceText.text = distance.ToString("F1") + "m";
    }
}
