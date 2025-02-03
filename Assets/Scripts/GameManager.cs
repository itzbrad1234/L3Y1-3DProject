using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float timer;
    public float timeLimit;
    public TMP_Text timerText;

    public Canvas inGame;
    public Canvas pauseMenu;

    public bool isPaused;


    // Start is called before the first frame update
    void Start()
    {
        timer = timeLimit;

        isPaused = false;
        inGame.enabled = true;
        pauseMenu.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timerText.text = timer.ToString("F2");

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (timer <= 0)
        {
            Debug.Log("Out of time.");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else
        {
            timer -= Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPaused = !isPaused;
        }

        if (isPaused)
        {
            Time.timeScale = 0f;
            inGame.enabled = false;
            pauseMenu.enabled = true;
        }
        else
        {
            Time.timeScale = 1f;
            inGame.enabled = true;
            pauseMenu.enabled = false;
        }
    }

    public void OnPlay()
    {
        isPaused = false;
    }

    public void OnExit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
