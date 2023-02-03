using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class placesCube : MonoBehaviour
{
    public GameObject cube;
    public Transform bois;

    // Start is called before the first frame update

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            //print(hit.collider.tag);
            if (hit)
            {
                if (hit.collider.CompareTag("Tree"))
                {
                    print("qqqqqq");
                    Vector3 mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    int x = Convert.ToInt32(mouse.x / 0.25f);
                    int y = Convert.ToInt32(mouse.y / 0.25f);
                    Vector3 vec = new Vector3((x * 0.25f), (y * 0.25f), -1);
                    Instantiate(cube,vec,Quaternion.identity, bois.transform);
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
                    Destroy(hit.collider.gameObject);
                }
            }

        }
    }
}

