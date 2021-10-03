using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MovableObject
{
    public float speed = 0.03f;
    public float verticalSpeedModifier = 0.7f;

    public int poopCount;
    public int waterCount;

    Animator animator;

    int MAX_WATER = 3;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        poopCount = 0;
        waterCount = 0;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ProcessInput();
    }

    void ProcessInput()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");


        if (xInput > 0)
        {
            //animator.SetTrigger("MoveRight");
            animator.Play("PlayerRight");
        }
        else if(xInput < 0)
        {
            //animator.SetTrigger("MoveLeft");
            animator.Play("PlayerLeft");
        }
        else if(yInput > 0)
        {
            //animator.SetTrigger("MoveUp");
            animator.Play("PlayerUp");
        }
        else if(yInput < 0)
        {
            //animator.SetTrigger("Idle");
            animator.Play("PlayerIdleAndDown");
        }

        Vector2 movementDirection = new Vector2(xInput, yInput);
        movementDirection = movementDirection.normalized * speed;
        movementDirection.y *= verticalSpeedModifier;

        if (movementDirection.magnitude != 0)
        {
            int collisionMask = LayerMask.GetMask("wall");
            int poopMask = LayerMask.GetMask("poop");
            Move(movementDirection, collisionMask, poopMask, HandleCollisions);
        }
    }

    void HandleCollisions(Collider2D collider)
    {
        //just here so we can pick up poop when we walk over it
        if (1 << collider.gameObject.layer == LayerMask.GetMask("poop"))
        {
            //poopCount += 1;
            ResourceManager.IncrementPoop();
            Destroy(collider.gameObject);
        }
    }
}
