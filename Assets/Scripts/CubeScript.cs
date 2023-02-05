using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public bool selected = false;
    public bool digged = false;
    public string room;

    

    public DigManager digManager;
    public HealthTree healthTree;

    Color Coridor = new Color(0.72f, 0.72f, 0.72f);
    Color Nurserie = new Color(0.73f, 0.32f, 0.55f);
    Color StockMiellat = new Color(0.88f, 0.71f, 0.22f );
    Color StockEau = new Color(0.38f, 0.53f , 0.39f );
    Color FarmPuce = new Color(0.77f , 0.99f , 0.4f);

    
    

    public AntStateManager antAssociated;
    public void isClicked()
    {
        if (!selected)
        {
            GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f);
        }


        selected = true;
    }

    public void isDigged()
    {
        digManager.gameObject.GetComponent<AudioSource>().Play();
        switch (room)
        {
            case "coridor":
                GetComponent<SpriteRenderer>().color = Coridor;
                digManager.nbCoridor++;
                healthTree.getHurt(1);
                break;
            case "nurserie":
                GetComponent<SpriteRenderer>().color = Nurserie;
                digManager.nbNurserie++;
                healthTree.getHurt(10);
                break;
            case "stockEau":
                GetComponent<SpriteRenderer>().color = StockEau;
                digManager.nbEau++;
                healthTree.getHurt(2);
                break;
            case "stockMiella":
                GetComponent<SpriteRenderer>().color = StockMiellat;
                digManager.nbMiellat++;
                healthTree.getHurt(2);
                break;
            case "farmPuce":
                digManager.nbFarm++;
                GetComponent<SpriteRenderer>().color = FarmPuce;
                healthTree.getHurt(4);
                break;
        }
        digged = true;
        selected = false;
        gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }

    public void isDeclicked()
    {
        if (selected)
        {
            GetComponent<SpriteRenderer>().color = new Color(0.7450981f, 0.4941177f, 0.1529412f) ;
        }


        selected = false;
    }
}
