using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //movement variables that we can edit in engine
    public float groundThrust = 5f;
    public float jumpThrust = 5f;
    public float maxThrustVelocity = 25.0f;


    //allowing the script to find the ground
    public LayerMask groundLayerMask;


    //components on player game object
    private CircleCollider2D circleColl;
	private Rigidbody2D rb;


    private void Start()
    {
        //get a reference to the rigid body component
        rb = GetComponent<Rigidbody2D>();

        //get a reference to the collider component
        circleColl = GetComponent<CircleCollider2D>();

    }

    private void Update()
    {
        //this function runs EVERY frame of the game.

        //first, we need to see if we're on the ground
        if (CheckForGround())
        {
            //if we are on the ground, we need to see if the player jumped
            if (Input.GetButtonDown("Jump"))
            {
                //if the player jumped, add FORCE in the up direction
                rb.AddForce(Vector2.up * jumpThrust, ForceMode2D.Impulse);
            }
        }

        //reset if they fall off
        if (rb.position.y < -10)
        {
            //set position
            rb.position = new Vector2(0,2);
            //set velocity
            rb.velocity = new Vector2(0, 0);
            //set angular velocity
            rb.angularVelocity = 0;
            //set rotation
            rb.SetRotation(0);
        }
    }

    private void FixedUpdate()
    {
        //this function runs in SET INTERVALS
        //Not defined by framerate

        //see if the left/right input keys are pressed
        //store how "pressed" they are in a number
        float horizontalInput = Input.GetAxis("Horizontal");

        //  if the player is moving too fast           OR   the velocity of the player is NOT the same as the horizontal input
        if (rb.velocity.magnitude <= maxThrustVelocity || Mathf.Sign(rb.velocity.x) != Mathf.Sign(horizontalInput))
        {
            //add FORCE to the player in the direction they pressed
            rb.AddForce(Vector2.right * horizontalInput * groundThrust);
        }
    }

    private bool CheckForGround()
    {
        //This function checks to see if the player is grounded.
        //grounded means that it is colliding with any surface.

        //defining an offset of the hitbox for collisions
        float hitboxOffset = circleColl.bounds.extents.x / 1.5f;

        //defining a hitbox witdth for calculations
        float hitboxWidth = 0.5f;

        //Make a 2D position for the top left part of this hitbox
        Vector2 hitboxTopLeft = new Vector2(transform.position.x - hitboxOffset,
                                            transform.position.y - hitboxOffset);

        //Mave a 2D position for the bottom right part of the hitbox
        Vector2 hitboxBottomRight = new Vector2(transform.position.x + hitboxOffset,
                                                transform.position.y - (hitboxOffset + hitboxWidth));

        //drawing a line between the topleft hitbox and the bottom right of the hitbox
        //(only in scene view)
        Debug.DrawLine(hitboxTopLeft, hitboxBottomRight, Color.green);

        //returns true or false for whether or not the player hitbox and the ground hitbox overlap
        return Physics2D.OverlapArea(hitboxTopLeft, hitboxBottomRight, groundLayerMask);
    }
}
