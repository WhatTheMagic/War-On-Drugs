using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    [SerializeField] private PlayerTurn playerTurn;
    [SerializeField] private GameObject pauseMenu;
    public static bool gameIsPaused;

    [SerializeField] private GameObject playerCam;

    public void StartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1;
        Cursor.visible = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Menu()
    {
        SceneManager.LoadScene(0);
        Cursor.visible = true;
    }

    void Update()
    {
        bool IsPlayerTurn = playerTurn.IsPlayerTurn();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPlayerTurn)
            {
                gameIsPaused = !gameIsPaused;
                PauseGame();
            }
        }
    }

    void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
            Cursor.visible = true;
            playerCam.SetActive(false); 

        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
            Cursor.visible = false;
            playerCam.SetActive(true);
        }
    }
}
