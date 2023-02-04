using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DigManager : MonoBehaviour
{
    public GameObject Ants;
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
                    SeekFreeAnt(hit.collider.gameObject, hit);
                    
                    
                }
            }
            
        }
        if (Input.GetMouseButton(1))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            //print(hit.collider.tag);
            if (hit)
            {
                if (hit.collider.CompareTag("cube") && hit.collider.GetComponent<CubeScript>().selected)
                {
                    hit.collider.GetComponent<CubeScript>().isDeclicked();
                    AntStateManager cubeAnt = hit.collider.GetComponent<CubeScript>().antAssociated;
                    cubeAnt.SwitchState(cubeAnt.IdleState);
                    cubeAnt.occupied = false;
                }
            }

        }
    }
    void SeekFreeAnt(GameObject cube, RaycastHit2D hit)
    {
        if (!cube.GetComponent<CubeScript>().selected)
        {
            foreach (AntStateManager ant in Ants.GetComponentsInChildren<AntStateManager>())
            {
                if (!ant.occupied)
                {
                    hit.collider.GetComponent<CubeScript>().isClicked();
                    hit.collider.GetComponent<CubeScript>().antAssociated = ant;
                    AntGoingDig GoingDigState = new AntGoingDig(cube);
                    ant.SwitchState(GoingDigState);
                    ant.occupied = true;
                    
                    break;
                }
            }
        }
    }
}
