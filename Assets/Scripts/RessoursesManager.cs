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
    float productionCoolDown = 2f;
    float timeElapsed = 0f;
    public TextMeshProUGUI eauText;
    public TextMeshProUGUI miellatText;

    private void Update()
    {
        int eauLimit = digManager.nbEau*2;
        int miellatLimit = digManager.nbMiellat;

        if (timeElapsed< productionCoolDown)
        {
            timeElapsed += Time.deltaTime;
            eauText.text = eauAmount + "/" + eauLimit;
            miellatText.text = miellatAmount + "/" + miellatLimit;
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
            eauText.text = eauAmount + "/" + eauLimit;
            miellatText.text = miellatAmount + "/" + miellatLimit;
        }
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
