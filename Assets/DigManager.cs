using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigManager : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            //print(hit.collider.tag);
            if (hit)
            {
                if (hit.collider.CompareTag("cube"))
                {
                    hit.collider.GetComponent<CubeScript>().isClicked();
                }
            }
            
        }
        if (Input.GetMouseButton(1))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            //print(hit.collider.tag);
            if (hit)
            {
                if (hit.collider.CompareTag("cube"))
                {
                    hit.collider.GetComponent<CubeScript>().isDeclicked();
                }
            }

        }
    }
}
