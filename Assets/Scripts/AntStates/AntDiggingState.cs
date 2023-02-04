using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntDiggingState : AntBaseState
{
    public float digTime = 1.5f;
    float timeElapsed = 0;
    GameObject cube;
    public AntDiggingState(GameObject c)
    {
        this.cube = c;
    }
    public override void EnterState(AntStateManager ant)
    {
        Debug.LogWarning("Diggi hole(V2)");
    }
    public override void UpdateState(AntStateManager ant)
    {
        while (timeElapsed > digTime)
        {
            timeElapsed += Time.deltaTime;
            ant.transform.Rotate(0, 0, Random.Range(-5.0f, 5f));
        }
        Object.Destroy(cube);
        ant.occupied = false;
        ant.SwitchState(ant.IdleState);
    }
    public override void OnCollisionEnter(AntStateManager ant, Collision2D collision)
    {

    }
}
