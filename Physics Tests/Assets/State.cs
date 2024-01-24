using UnityEngine;
public abstract class State //Abstract means we make the methods listed below on their files
{
    public abstract void BeginState(StateManager owner);
    public abstract void UpdateState(StateManager owner);
    public abstract void FixedUpdateState(StateManager owner);
    public abstract void EndState(StateManager owner);
}
