using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody rigidBody;
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float xBorder;
    
    private float horizontalInput;
    private bool isMoving = true;


    /// Functions

    /*private void Awake() // Invoke functions to set forwardSpeed, horizontalSpeed, xBorder based on active scene. For example:
    {
        //SetSpeed()
        //SetBorder()
    }*/

    // Anything that affects a RigidBody, should be executed in FixedUpdate
    void FixedUpdate()
    {
        if (!isMoving) return;

        RestrictPlayerMovement();
        
        Vector3 forwardMove = forwardSpeed * Time.fixedDeltaTime * transform.forward;
        Vector3 horizontalMove = horizontalInput * horizontalSpeed * Time.fixedDeltaTime * transform.right;

        // Move Player
        rigidBody.MovePosition(rigidBody.position + forwardMove + horizontalMove);
    }


    // Detect user input
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }


    // Restrict Player movement on x Axis
    void RestrictPlayerMovement()
    {
        float xPosition = Mathf.Clamp(rigidBody.position.x, -xBorder, xBorder);
        rigidBody.position = new Vector3(xPosition, rigidBody.position.y, rigidBody.position.z);
    }


    public void StopMovement()
    {
        isMoving = false;
        Cursor.visible = true;
    }
}
