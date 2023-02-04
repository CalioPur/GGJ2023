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

    private void GetXY(Vector3 worldPos, out int x, out int y)
    {
        x = Mathf.FloorToInt(worldPos.x / this.cellSize);
        y = Mathf.FloorToInt(worldPos.y / this.cellSize);
    }

    public void SetValue(int x, int y, int value)
    {
        if (x >=0 && y>=0 && x<this.width && y < this.height)
        {
            this.gridArray[x, y] = value;
            Debug.Log(x + " " + y);
        }
    }

    public void SetValue(Vector3 worldPos, int val)
    {
        int x, y;
        GetXY(worldPos, out x, out y);
        SetValue(x, y, val);
    }
}
