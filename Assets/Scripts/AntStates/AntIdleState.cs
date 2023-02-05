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

        ant.transform.Rotate(0, 0, Random.Range(-10.0f, 10f) * Time.deltaTime * 500);

    }
    public override void OnCollisionEnter(AntStateManager ant, Collision2D collision)
    {
        //if idle but encounters selected cube
        if (collision.gameObject.CompareTag("cube") && collision.gameObject.GetComponent<CubeScript>().selected)
        {
            ant.SwitchState(new AntDiggingOther(collision.gameObject, null));
        }
    }
}
