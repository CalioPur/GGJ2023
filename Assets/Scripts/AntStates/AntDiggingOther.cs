using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntDiggingOther : AntBaseState
{
    public float digTime = .5f;
    float timeElapsed = 0;
    GameObject otherCube,expectedCube;
    public AntDiggingOther(GameObject c, GameObject c2)
    {
        this.otherCube = c;
        this.expectedCube = c2;
    }

    public override void EnterState(AntStateManager ant)
    {
        Debug.Log("digging other");
    }

    public override void UpdateState(AntStateManager ant)
    {
        if (timeElapsed < digTime)
        {
            timeElapsed += Time.deltaTime;
            ant.transform.Rotate(0, 0, (Random.Range(-5.0f, 5f))*Time.deltaTime*500);
        }
        else
        {
            otherCube.GetComponent<CubeScript>().isDigged();

            //warn other ant to not seek its assigned cube anymore
            AntStateManager otherAnt = otherCube.GetComponent<CubeScript>().antAssociated;
            otherAnt.occupied = false;
            otherAnt.SwitchState(otherAnt.IdleState);

            //idle if no asigned cube, going dig if assigned cube
            if (expectedCube != null)
            {
                ant.SwitchState(new AntGoingDig(expectedCube));
            }
            else
            {
                ant.occupied = false;
                ant.SwitchState(ant.IdleState);
            }
        }
    }

    public override void OnCollisionEnter(AntStateManager ant, Collision2D collision)
    {
        
    }

}
