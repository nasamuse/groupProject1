using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : MonoBehaviour 
{
    private State currMovementState;
    private State currCombatState;
    public PlayerController player;

    //Movement States
    public Idle IdleState = new Idle();
    public InAir InAirState= new InAir();
    public TopSpeed TopSpeedState = new TopSpeed();
    public Grounded GroundedState = new Grounded();
    public Falling FallingState = new Falling();

    //Combat States
    
    void Start()
    {
        player = this.GetComponent<PlayerController>();

        //Set to Idles and Begin
        currMovementState = IdleState;
        currMovementState.BeginState(this);
    }

    // Update is called once per frame
    void Update()
    {// And we call our current State's Updates
        currMovementState.UpdateState(this);
    }
    
    //Runs 50 times a second (for physics)
    void FixedUpdate()
    {// Again, we call the current State's Fixed Updates
        currMovementState.FixedUpdateState(this);
    }
    public void SwapState(State newState){
        //Debug.Log(currMovementState + " to " + newState);
        currMovementState.EndState(this); //When we swap, we have to end the current state
        currMovementState = newState; 
        newState.BeginState(this); // Beginning statements
    }
}
