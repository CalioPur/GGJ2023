using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RessoursesManager : MonoBehaviour
{

    int miellatAmount = 0;
    int eauAmount = 0;

    public DigManager digManager;
    public HealthTree healthTree;
    public GameObject Ants;
    float productionCoolDown = 2f;
    float timeElapsed = 0f;
    public TextMeshProUGUI eauText;
    public TextMeshProUGUI miellatText;
    public TextMeshProUGUI antText;

    private void Update()
    {
        int eauLimit = digManager.nbEau*2;
        int miellatLimit = digManager.nbMiellat;
        int antAmount = Ants.transform.childCount;

        if (timeElapsed< productionCoolDown)
        {
            timeElapsed += Time.deltaTime;
        }
        else
        {
            timeElapsed = 0;
            eauAmount += (digManager.nbEau / 10);
            miellatAmount += (digManager.nbFarm / 10);
            

            if (eauAmount > eauLimit)
            {
                eauAmount = eauLimit;
            }
            if (miellatAmount > miellatLimit)
            {
                miellatAmount = miellatLimit;
            }
            
        }
        

        eauText.text = eauAmount + "/" + eauLimit;
        miellatText.text = miellatAmount + "/" + miellatLimit;
        antText.text = antAmount + "/100";
    }

    
    public void regenerateTree()
    {
        if(eauAmount>=10 && miellatAmount >= 10)
        {
            eauAmount -= 10;
            miellatAmount -= 10;
            healthTree.getHurt(-20);
        }
    }

}
