using UnityEngine;
using UnityEngine.InputSystem;

public class Idle : State //Extends the methods from "State.cs" - Meaning we can OVERRIDE them and make our own methods
{
    public PlayerController player;
    
    public override void BeginState(StateManager owner){
        player = owner.player;
        //Grabs inputs possible on the ground
        player.actions.FindActionMap("Normal").FindAction("Jump").performed += OnJump;
        player.actions.FindActionMap("Normal").FindAction("Shift").performed += OnShift;
    }
    public override void UpdateState(StateManager owner){
        if(player.currSpeed > .1f && player.isGrounded)
        {
            owner.SwapState(owner.GroundedState);
        }
    }
    public override void EndState(StateManager owner){
        
    }
    public override void FixedUpdateState(StateManager owner){
        player.Moving();
    }
    public void OnJump(InputAction.CallbackContext context){
        player.Jump();
    }
    public void OnShift(InputAction.CallbackContext context){
        player.Shift();
    }
}

