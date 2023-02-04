
using UnityEngine;

public abstract class AntBaseState 
{
    public abstract void EnterState(AntStateManager ant);
    
    public abstract void UpdateState(AntStateManager ant);

    public abstract void OnCollisionEnter(AntStateManager ant, Collision2D collision);

}
