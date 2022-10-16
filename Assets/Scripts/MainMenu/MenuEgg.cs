using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEgg : MonoBehaviour
{
    [SerializeField] float fallingSpeed;

    [SerializeField] int xPointLeft = 15;
    [SerializeField] int xPointRight = 75;
    
    [SerializeField] int bottomPoint = -75; // If object falls below this point on the y axis
    [SerializeField] int topPoint = 60; // Reset object's position to this point on the y axis


    /// Functions ///

    void Update()
    {
        ApplyTerminalVelocity();

        if (transform.position.y < bottomPoint)
        {
            ResetEggPosition();
        }
    }


    private void ApplyTerminalVelocity()
    {
        transform.Translate(fallingSpeed * Time.deltaTime * Vector3.down, Space.World);
    }


    void OnMouseDown()
    {
        ResetEggPosition();
    }


    private void ResetEggPosition() // Get a random x position to reset object to at topBorder y. Give it a random rotation at z.
    {
        float xRandomPos = Random.Range(xPointLeft, xPointRight);
        transform.position = new Vector3(xRandomPos, topPoint, transform.position.z);
        transform.Rotate(0, 0, Random.Range(-0, 360));
    }
}
