using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Testing : MonoBehaviour
{
    private Grid grid;
    private void Start()
    {
        grid = new Grid(85, 20, 0.25f);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            grid.SetValue(Camera.main.ScreenToWorldPoint(Input.mousePosition), 10);
        }
    }
}
