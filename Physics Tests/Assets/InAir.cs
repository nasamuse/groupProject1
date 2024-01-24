using UnityEngine;

public class InAir : State //Extends the methods from "State.cs" - Meaning we can OVERRIDE them and make our own methods
{
    PlayerController player;
    public override void BeginState(StateManager owner){
        player = owner.player;
        
    }
    public override void UpdateState(StateManager owner){
        if(player.body.velocity.y < 0f){
            owner.SwapState(owner.FallingState);
        }
    }
    public override void EndState(StateManager owner){
        
    }
    public override void FixedUpdateState(StateManager owner){
        player.AboveMoving(); //Above GroundSpeed
    }
}
