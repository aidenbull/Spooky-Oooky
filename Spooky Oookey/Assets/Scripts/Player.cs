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

    static float interactionTimer = 0f;
    //Supposed to be equal to the length of the interact animation
    static float INTERACTION_TIME = 0.5f;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        poopCount = 0;
        waterCount = 0;
        animator = GetComponent<Animator>();
        EventManager.OnInteract += StartInteract;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ProcessInput();
    }

    void ProcessInput()
    {
        //Can't do anything while interacting
        if (interactionTimer < 0f)
        {
            float xInput = Input.GetAxis("Horizontal");
            float yInput = Input.GetAxis("Vertical");

            //Using play instead of settrigger here because the animator is set so any animation can play from any animation, therefore animations can interrupt themselves
            if (xInput > 0)
            {
                //animator.SetTrigger("MoveRight");
                animator.Play("PlayerRight");
            }
            else if (xInput < 0)
            {
                //animator.SetTrigger("MoveLeft");
                animator.Play("PlayerLeft");
            }
            else if (yInput > 0)
            {
                //animator.SetTrigger("MoveUp");
                animator.Play("PlayerUp");
            }
            else if (yInput < 0)
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
        else
        {
            interactionTimer -= Time.deltaTime;
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

    void StartInteract()
    {
        interactionTimer = INTERACTION_TIME;
        animator.SetTrigger("Interact");
    }
}
