using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntDiggingState : AntBaseState
{
    public float digTime = .5f;
    float timeElapsed = 0;
    GameObject cube;
    public AntDiggingState(GameObject c)
    {
        this.cube = c;
    }
    public override void EnterState(AntStateManager ant)
    {
        //Debug.LogWarning("Diggi hole(V2)");
    }
    public override void UpdateState(AntStateManager ant)
    {
        if (timeElapsed < digTime)
        {
            timeElapsed += Time.deltaTime;
            ant.transform.Rotate(0, 0, Random.Range(-5.0f, 5f) * Time.deltaTime * 100);
        }
        else
        {
            cube.GetComponent<CubeScript>().isDigged();
            ant.occupied = false;
            ant.SwitchState(ant.IdleState);
        }
        //ant.transform.rotation = new Quaternion(0, 0, ant.transform.rotation.z, ant.transform.rotation.w);

    }
    public override void OnCollisionEnter(AntStateManager ant, Collision2D collision)
    {

    }
}
