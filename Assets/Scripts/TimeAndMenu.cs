using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeAndMenu : MonoBehaviour
{
    public GameObject fastButton;
    public GameObject regularButton;

    public GameObject pausePannel;

    public void pauseGame()
    {
        pausePannel.SetActive(true);
        Time.timeScale = 0;
    }

    public void speedUpGame()
    {
        fastButton.SetActive(false);
        regularButton.SetActive(true);

        Time.timeScale = 2;
        print("speed up");
    }

    //resume game is also used to reset game to regular speed
    public void resumeGame()
    {
        pausePannel.SetActive(false);

        fastButton.SetActive(true);
        regularButton.SetActive(false);

        Time.timeScale = 1;
        print("speed down");
    }

    public void mainMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
