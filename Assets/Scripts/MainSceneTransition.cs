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
    public GameObject deathText;
    // Update is called once per frame
    void Start()
    {
        deathText = GameObject.FindWithTag("deathText");
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Destroy(deathText);
            LoadNextLevel();
        }
        if (playerDeath.isWin == true) 
        {
            LoadWinlevel();
        }
    }

    public void LoadWinlevel()
    {
        timeReset.TimeScale = 1f;
        //playerDeath.pitchValue = 1f;
        StartCoroutine(LoadWin(SceneManager.GetActiveScene().buildIndex + 1));

    }

    IEnumerator LoadWin(int levelIndex)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(0.35f);
        SceneManager.LoadScene(levelIndex);
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
