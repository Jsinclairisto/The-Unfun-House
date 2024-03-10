using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainSceneTransition : MonoBehaviour
{
    [SerializeField]
    private Animator transition;
    [SerializeField]
    private PlayerMovement playerDeath;
    [SerializeField]
    private TimeControl timeReset;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            LoadNextLevel();
        }
    }

    public void LoadNextLevel()
    {
        timeReset.TimeScale = 1f;
        playerDeath.pitchValue = 1f;
        StartCoroutine(LoadLevel());

    }

    IEnumerator LoadLevel()
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(0.40f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}