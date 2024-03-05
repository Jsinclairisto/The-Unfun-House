using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeControl : MonoBehaviour
{

    [Header("Time Scale")]
    public float TimeScale;

    private float StartTimeScale;
    private float StartFixedDeltaTime;
    void Start()
    {
        StartTimeScale = Time.timeScale;
        StartFixedDeltaTime = Time.fixedDeltaTime;
    }

    // Update is called once per frame
    void Update()
    {
       
        StartSlowMotion();
        
/*        if (Input.GetKeyUp(KeyCode.Q)) 
        {
            StopSlowMotion();
        }*/
    }
    public void StartSlowMotion() 
    {
        Time.timeScale = TimeScale;
        Time.fixedDeltaTime = StartFixedDeltaTime * TimeScale;
    }
    public void StopSlowMotion() 
    {
        Time.timeScale = StartTimeScale;
        Time.fixedDeltaTime = StartFixedDeltaTime;
    }
}
