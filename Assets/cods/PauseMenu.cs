using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool ispaused;

    public GameObject canvasPause;

    public CharacterHealth health;

    public EnemySpawner spawner;

    void Update()
    {
        if(!health.gameOver && Input.GetKeyDown(KeyCode.Escape))
        {
            if(ispaused)
            {
                Resume();
            } else
            {
                spawner.powerUp.SetActive(false);
                Pause();
            }
        }
    }

    public void Resume()
    {
        FindFirstObjectByType<AudioManager>().Play("font");
        canvasPause.SetActive(false);
        Time.timeScale = 1f;

        ispaused = false;
    }

    public void Pause()
    {
        canvasPause.SetActive(true);
        Time.timeScale = 0f;
        ispaused = true;
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }
}
