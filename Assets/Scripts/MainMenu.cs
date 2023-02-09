using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject creditsPanel;
    public GameObject HtPPanel;

    public void Start()
    {
        Time.timeScale = 1;        
    }

    public void Quit()
    {
        print("quitting");
        Application.Quit();
    }

    public void Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void CreditsOpen()
    {
        creditsPanel.SetActive(true);
    }

    public void HowToPlayOpen()
    {
        HtPPanel.SetActive(true);
    }

    public void CreditsClose()
    {
        creditsPanel.SetActive(false);
    }

    public void HowToPlayClose()
    {
        HtPPanel.SetActive(false);
    }
}
