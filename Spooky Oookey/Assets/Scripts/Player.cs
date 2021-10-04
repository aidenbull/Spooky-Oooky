using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MovableObject
{
    public float speed = 0.03f;
    public float verticalSpeedModifier = 0.7f;

    public int poopCount;
    public int waterCount;

    Animator animator;

    static float interactionTimer = 0f;
    //Supposed to be equal to the length of the interact animation
    static float INTERACTION_TIME = 0.5f;

    public GameObject DeathEffect;
    PumpkinEatEffect deathEffect;

    public GameObject PoofEffect;

    public int BoneValue = 50;

    // Start is called before the first frame update
    new void Start()
    {
        base.Start();
        poopCount = 0;
        waterCount = 0;
        animator = GetComponent<Animator>();

        deathEffect = DeathEffect.GetComponent<PumpkinEatEffect>();
        deathEffect.Init(GameOver);
        DeathEffect.SetActive(false);

        EventManager.OnInteract += StartInteract;
        EventManager.OnGameOver += OnGameOver;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!dead)
        {
            ProcessInput();
        }
        else
        {
            PlayDeathEffect();
        }
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
                int boneMask = LayerMask.GetMask("bone");
                int miscMask = poopMask + boneMask;
                Move(movementDirection, collisionMask, miscMask, HandleCollisions);
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
        //BONELESS CHICKEN
        if (1 << collider.gameObject.layer == LayerMask.GetMask("bone"))
        {
            ResourceManager.AddMoney(BoneValue);
            Destroy(collider.gameObject);
        }
    }

    void StartInteract()
    {
        interactionTimer = INTERACTION_TIME;
        animator.SetTrigger("Interact");
    }

    void OnGameOver()
    {
        if (!dead)
        {
            dead = true;
            DeathEffect.SetActive(true);
            deathEffect.Eat();
            animator.SetTrigger("Die");
        }
    }

    bool dead = false;
    float eatTime = 2.33f;
    bool poofed = false;
    void PlayDeathEffect()
    {
        eatTime -= Time.deltaTime;
        if (eatTime < 0f)
        {
            GetComponent<SpriteRenderer>().enabled = false;
            if (!poofed)
            {
                poofed = true;
                GameObject poofInstance = Instantiate(PoofEffect);
                poofInstance.transform.position = transform.position + new Vector3(0f, 0.2f, -1f);
            }
        }
    }

    void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
