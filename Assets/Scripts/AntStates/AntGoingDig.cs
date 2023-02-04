using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntGoingDig : AntBaseState
{
    GameObject cube;
    public AntGoingDig(GameObject c)
    {
        this.cube = c;
    }
    public override void EnterState(AntStateManager ant)
    {
        ant.transform.right = -(cube.transform.position - ant.transform.position);
    }
    public override void UpdateState(AntStateManager ant)
    {
        ant.transform.position += (-ant.transform.right) * (Time.deltaTime * 0.5f);
        ant.transform.right = -(cube.transform.position - ant.transform.position);
        ant.transform.Rotate(0, 0, Random.Range(-30.0f, 30f));
    }
    public override void OnCollisionEnter(AntStateManager ant, Collision2D collision)
    {
        if(collision.gameObject == cube)
        {
            ant.SwitchState(new AntDiggingState(cube));
        }
    }
}
