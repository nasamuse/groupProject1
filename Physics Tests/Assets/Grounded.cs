using UnityEngine;

public class Grounded : Idle //Extends the methods from "State.cs" - Meaning we can OVERRIDE them and make our own methods
{
    public override void UpdateState(StateManager owner){
        if(player.currSpeed < .1f)
        {
            owner.SwapState(owner.IdleState);
        }
    }
    public override void EndState(StateManager owner){
        
    }
}

