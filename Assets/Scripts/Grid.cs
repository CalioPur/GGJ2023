using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid 
{
    private int width;
    private int height;
    private float cellSize;
    private int[,] gridArray;

    public Grid(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        this.gridArray = new int[this.width, this.height];

        //visualisation
        for(int x = 0; x < this.gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < this.gridArray.GetLength(1); y++)
            {
                Debug.Log(x + " " + y);
                Debug.Log(GetWorldPosition(x, y));
                Debug.DrawLine(GetWorldPosition(x,y),GetWorldPosition(x,y+1), Color.red, 100f);
                Debug.DrawLine(GetWorldPosition(x, y), GetWorldPosition(x+1, y), Color.red, 100f);
            }
        }
        Debug.DrawLine(GetWorldPosition(0, height), GetWorldPosition(width, height), Color.red, 100f,false);
        Debug.DrawLine(GetWorldPosition(width, 0), GetWorldPosition(width, height), Color.red, 100f,false);
    }

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x,y) * this.cellSize;
    }
}
