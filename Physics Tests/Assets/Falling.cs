using UnityEngine;

public class Falling : State //Extends the methods from "State.cs" - Meaning we can OVERRIDE them and make our own methods
{
    PlayerController player;
    public override void BeginState(StateManager owner){
        player = owner.player;
        player.body.gravityScale = player.adjustedGravity; //Fall faster
    }
    public override void UpdateState(StateManager owner){
        
    }
    public override void EndState(StateManager owner){
        
    }
    public override void FixedUpdateState(StateManager owner){
        player.AboveMoving(); //Above GroundSpeed
    }
}
