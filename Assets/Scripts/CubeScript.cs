using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    public bool selected = false;
    public AntStateManager antAssociated;
    public void isClicked()
    {
        if (!selected)
        {
            GetComponent<SpriteRenderer>().color = new Color(0f, 1f, 0f);
        }


        selected = true;
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
