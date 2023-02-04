using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntIdleState : AntBaseState
{
    public override void EnterState(AntStateManager ant)
    {
        Debug.Log("bonjour, je suis une fourmi");
    }
    public override void UpdateState(AntStateManager ant)
    {
        ant.transform.position += (-ant.transform.right) * (Time.deltaTime * 0.5f);



        ant.transform.Rotate(0, 0, Random.Range(-10.0f, 10f));

    }
    public override void OnCollisionEnter(AntStateManager ant, Collision2D collision)
    {

    }
}
