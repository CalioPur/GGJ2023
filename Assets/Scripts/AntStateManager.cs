using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntStateManager : MonoBehaviour
{
    AntBaseState currentState;

    public AntIdleState IdleState = new AntIdleState();
    //public AntGoingDig GoingDigState = new AntGoingDig();
    //public AntDiggingState DiggingState = new AntDiggingState();

    public bool occupied;

    private void Start()
    {
        currentState = IdleState;
        currentState.EnterState(this);
    }
    private void Update()
    {
        currentState.UpdateState(this);
    }
    public void SwitchState(AntBaseState state)
    {
        currentState = state;
        currentState.EnterState(this);
    }
    public void OnCollisionStay2D(Collision2D collision)
    {
        currentState.OnCollisionEnter(this, collision);
    }


}
