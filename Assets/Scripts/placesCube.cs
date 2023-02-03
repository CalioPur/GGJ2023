using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class placesCube : MonoBehaviour
{
    public GameObject cube;
    public int row;
    public int col;

    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i<col; i++)
        {
            for (int j = 0; j < row; j++)
            {
                Vector3 vec = new Vector3(transform.position.x + 0.5f * i, transform.position.y - 0.5f * j, 0);
                Instantiate(cube, vec, Quaternion.identity, transform);
            }
        }
    }

}
