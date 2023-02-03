using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public int sensitivity;
    public float camSpeed;
    float Ypos = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Ypos += Input.GetAxis("Mouse ScrollWheel") * sensitivity * Time.deltaTime;
        if (Ypos > 5.2f)
        {
            Ypos = 5.2f;
        }
        else if(Ypos< -16.8f)
        {
            Ypos = -16.8f;
        }
        Vector3 vec = new Vector3(transform.position.x, Ypos, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, vec, camSpeed);
    }
}
