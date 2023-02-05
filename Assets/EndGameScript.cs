using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndGameScript : MonoBehaviour
{
    public GameObject Ants;
    public HealthTree healthTree;

    public GameObject winPanel;
    public GameObject LosePanel;

    // Update is called once per frame
    void Update()
    {
        if (Ants.transform.childCount >= 200)
        {
            Time.timeScale = 0f;
            winPanel.SetActive(true);
        }
        if (healthTree.life <= 0)
        {
            Time.timeScale = 0f;
            LosePanel.SetActive(true);
        }
    }
}
