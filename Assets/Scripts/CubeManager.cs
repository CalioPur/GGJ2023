using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public List<CubeScript> cubeScriptList = new List<CubeScript>();
    //public float testingFloat = 0.2f;

    public void GenerateMatrix()
    {

        int[,] marchingSquareArray;
        Vector2 minPosition = new Vector2(float.PositiveInfinity, float.PositiveInfinity); 
        Vector2 maxPosition = new Vector2(float.NegativeInfinity, float.NegativeInfinity); 
        int maxIndexX, maxIndexY;
        float stepSize = 0.25f;

        cubeScriptList.OrderBy(cubescript => cubescript.transform.position.x).ThenBy((cubescript => cubescript.transform.position.x));


        foreach(CubeScript cubescript in cubeScriptList)
        {
            Vector2 cubePosition = cubescript.transform.position;
            if (cubePosition.x > maxPosition.x) maxPosition.x = cubePosition.x;
            if (cubePosition.y > maxPosition.y) maxPosition.y = cubePosition.y;
            if (cubePosition.x < minPosition.x) minPosition.x = cubePosition.x;
            if (cubePosition.y < minPosition.y) minPosition.y = cubePosition.y;
        }
        maxIndexX = (int)((maxPosition.x - minPosition.x) / ((float)stepSize))+1;
        maxIndexY = (int)((maxPosition.y - minPosition.y) / ((float)stepSize))+1;

        string messageDebug = "[DEBUG] Final Results";
        messageDebug += "\n\t minPosition = " + minPosition;
        messageDebug += "\n\t maxPosition = " + maxPosition;
        messageDebug += "\n\t maxIndexX = " + maxIndexX + " and maxIndexY = " + maxIndexY;

        marchingSquareArray = new int[maxIndexX, maxIndexY];
        foreach (CubeScript cubescript in cubeScriptList)
        {
            Vector2 cubePosition = cubescript.transform.position;
            int indexCubeX = (int)((cubePosition.x - minPosition.x) / ((float)stepSize));
            int indexCubeY = (int)((cubePosition.y - minPosition.y) / ((float)stepSize));
            if (indexCubeX < marchingSquareArray.GetLength(0) && indexCubeY < marchingSquareArray.GetLength(1))
                marchingSquareArray[indexCubeX, indexCubeY] = 1;
            else messageDebug += "\n Error at (" + indexCubeX + "," + indexCubeY + ")";
        }
        
        messageDebug += "\n\n array result : ";
        for (int indexY = marchingSquareArray.GetLength(1)-1; indexY >= 0; indexY--)
        {
            messageDebug += "\n";
            for (int indexX = 0; indexX < marchingSquareArray.GetLength(0); indexX++)
            {
                messageDebug += marchingSquareArray[indexX, indexY] ;
            }
        }


        Debug.Log(messageDebug);
    }
}
