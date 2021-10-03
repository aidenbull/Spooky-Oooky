using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowDogPig : SpookyObject
{
    Animator animator;
    SpriteRenderer spriteRenderer;

    public GameObject poop;

    float poopTimer;
    float POOP_CYCLE_MAX = 10f;
    float POOP_CYCLE_MIN = 6f;

    float walkTimer;
    bool walking;

    float WALK_CYCLE_MAX = 6f;
    float WALK_CYCLE_MIN = 3f;

    float wanderRadius = 2f;
    float widthToHeightRatio = 1.5f;
    public Vector2 pastureOrigin;

    Vector2 wanderTarget;
    float walkSpeed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        walkTimer = Random.Range(WALK_CYCLE_MIN, WALK_CYCLE_MAX);
        poopTimer = Random.Range(POOP_CYCLE_MIN, POOP_CYCLE_MAX);
        walking = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        HandleWandering();
        HandlePooping();
    }

    void HandleWandering()
    {
        if (walking)
        {
            Vector3 targetVector = new Vector3(wanderTarget.x, wanderTarget.y, transform.position.z) - transform.position;
            Vector3 wanderVector = targetVector.normalized * walkSpeed;
            if (targetVector.magnitude > wanderVector.magnitude) {
                //Still far from the destination so just continue moving
                transform.position += wanderVector;
            }
            else
            {
                //Reaching the destination now, update accordingly
                transform.position += targetVector;
                walking = false;
                animator.SetBool("Walking", false);
                walkTimer = Random.Range(WALK_CYCLE_MIN, WALK_CYCLE_MAX);
            }
        }
        else
        {
            walkTimer -= Time.deltaTime;
            if (walkTimer <= 0)
            {
                wanderTarget = GenerateRandomWanderCoordinate();
                //Turn around if need be
                if (wanderTarget.x < transform.position.x)
                {
                    spriteRenderer.flipX = false;
                }
                else
                {
                    spriteRenderer.flipX = true;
                }
                walking = true;
                animator.SetBool("Walking", true);
            }
        }
    }

    Vector2 GenerateRandomWanderCoordinate()
    {
        float angle = Random.Range(0, 2*Mathf.PI);
        float radius = Random.Range(0, wanderRadius);
        float x = radius * Mathf.Cos(angle) * widthToHeightRatio;
        float y = radius * Mathf.Sin(angle);

        return pastureOrigin + new Vector2(x, y);
    }

    void HandlePooping()
    {
        poopTimer -= Time.deltaTime;
        if(poopTimer <= 0)
        {
            poopTimer = Random.Range(POOP_CYCLE_MIN, POOP_CYCLE_MAX);
            Instantiate(poop, transform.position, transform.rotation);
        }
    }
}
