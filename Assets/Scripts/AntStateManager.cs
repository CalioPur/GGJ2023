using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntStateManager : MonoBehaviour
{
    AntBaseState currentState;

    AntIdleState IdleState = new AntIdleState();
    AntGoingDig GoingDigState = new AntGoingDig();
    AntDiggingState DiggingState = new AntDiggingState();

    private void Start()
    {
        currentState = IdleState;
        currentState.EnterState(this);
    }
    private void Update()
    {
        currentState.UpdateState(this);
    }


}
