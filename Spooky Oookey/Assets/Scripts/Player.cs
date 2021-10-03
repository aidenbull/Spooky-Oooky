using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovableObject
{
    public float speed = 0.007f;
    public float verticalSpeedModifier = 0.7f;


    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
    }

    void ProcessInput()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        Vector2 movementDirection = new Vector2(xInput, yInput);
        movementDirection = movementDirection.normalized * speed;
        movementDirection.y *= verticalSpeedModifier;

        if (movementDirection.magnitude != 0) Move(movementDirection);
    }


}
