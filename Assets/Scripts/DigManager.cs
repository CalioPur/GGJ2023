using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DigManager : MonoBehaviour
{
    public GameObject Ants;
    public GameObject ant;

    public int nbCoridor;
    public int nbNurserie;
    public int nbEau;
    public int nbMiellat;
    public int nbFarm;
    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            //print(hit.collider.tag);
            if (hit)
            {
                if (hit.collider.CompareTag("cube") && !hit.collider.GetComponent<CubeScript>().digged)
                {
                    hit.collider.GetComponent<CubeScript>().room = PlayerPrefs.GetString("roomType", "coridor");
                    SeekFreeAnt(hit.collider.gameObject, hit);
                    
                    
                }
                else if(hit.collider.CompareTag("Queen") && Ants.transform.childCount<nbNurserie/3) 
                {
                    Instantiate(ant, hit.collider.transform.position, hit.collider.transform.rotation, Ants.transform);
                }
            }
            
        }
        if (Input.GetMouseButton(1)&&!EventSystem.current.IsPointerOverGameObject())
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
