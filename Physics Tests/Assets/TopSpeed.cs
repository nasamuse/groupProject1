using UnityEngine;

public class TopSpeed : State //Extends the methods from "State.cs" - Meaning we can OVERRIDE them and make our own methods
{
    PlayerController player;

    public override void BeginState(StateManager owner){
        player = owner.player;
        player.body.gravityScale = 1f; //When landing, reset gravity to normal
        if(player.currSpeedX < 10){ //If too slow, lower back into Grounded
            owner.SwapState(owner.GroundedState);
        }
    }
    public override void UpdateState(StateManager owner){
        
    }
    public override void EndState(StateManager owner){
        

    }
    public override void FixedUpdateState(StateManager owner){
        player.AboveMoving(); //Above GroundSpeed
    }
}
