using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //Components Grab
    public InputActionAsset actions;
    public InputAction moveAction;
    public Rigidbody2D body;
    public Vector4 newColor;
    public SpriteRenderer spriteControl;
    public StateManager SM;

    //Everything speed related
    public Vector2 currVelocity;
    public float speed = .3f;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float fastestSpeed;
    private Vector2 tempVelocity;
    public float currSpeedX;
    public float currSpeedY;
    public float currSpeed;
    
    //Everything Jump related
    public float jumpForce;
    public float maxForce;
    public float adjustedGravity;

    //Everything Dash related

    public bool isGrounded;

    void Awake(){
        //Grab and activate components
        actions.Enable();
        SM = this.GetComponent<StateManager>();
        spriteControl = this.GetComponent<SpriteRenderer>();
        body = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        moveAction = actions.FindActionMap("Normal").FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        newColor = new Color(currSpeedX / 15, 0, 0, 1);
        spriteControl.color = newColor;
        currSpeed = Mathf.Abs(body.velocity.magnitude);
        currSpeedX = Mathf.Abs(body.velocity.x);
        currSpeedY = Mathf.Abs(body.velocity.y);
        Debug.Log(body.gravityScale);
    }

    //Physics Calculations
    void FixedUpdate(){
        
    }
    
    //Dash move, not yet implemented
    private void OnShift(InputAction.CallbackContext context){

    }

    //Collision Check - Right now only fitted for the Ground
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            isGrounded = true;
        }
        SM.SwapState(SM.TopSpeedState); //Landing assumes being above 8 speed - TopSpeed transitions into Grounded otherwise
    }

    //Movement Profile for Idle/Grounded States - If below 8
    public void Moving(){
        //Add force to Rigidbody quickly (Impulse)
        body.AddForce(moveAction.ReadValue<Vector2>() * speed, ForceMode2D.Impulse);
        //After adding force, make sure we're under the max speed
        if(currSpeedX > maxSpeed){
            body.velocity = Vector2.ClampMagnitude(body.velocity, maxSpeed);
        }
    }

    //Movement Profile for InAir/TopSpeed States - If below 10
    public void AboveMoving(){
        //Add force to Rigidbody quickly (Impulse)
        body.AddForce(moveAction.ReadValue<Vector2>() * .3f, ForceMode2D.Impulse);
        //After adding force, make sure we're under the max speed
        if(currSpeedX > fastestSpeed){
            body.velocity = Vector2.ClampMagnitude(body.velocity, fastestSpeed);
        }
    }
    public void Jump(){
        Vector2 up = new Vector2(0f, 1f);
        body.AddForce(up * jumpForce, ForceMode2D.Impulse);
        SM.SwapState(SM.InAirState);
    }
    public void Shift(){

    }
}
