using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumpokin : SpookyObject
{
    Animator animator;

    // Start is called before the first frame update

    public float growUpTimer = 10f;

    public enum GrowthState { Small, Large }
    GrowthState currGrowth;

    float AWAKE_TIMER_THRESHOLD = 10f;

    float MIN_RESOURCE_RESET = 20f;
    float MAX_RESOURCE_RESET = 30f;

    float waterTimer;
    float foodTimer;

    bool needsWater = false;
    bool needsFood = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        currGrowth = GrowthState.Small;
    }

    new void Update()
    {
        base.Update();
        if (currGrowth == GrowthState.Small)
        {
            CheckForGrow();
        }
        else
        {
            UpdateLargeState();
        }
    }

    void CheckForGrow()
    {
        if (growUpTimer > 0f)
        {
            growUpTimer -= Time.deltaTime;
        }
        else
        {
            GrowUp();
        }
    }

    void GrowUp()
    {
        currGrowth = GrowthState.Large;
        animator.SetTrigger("GrowUp");
        ResetWater();
        ResetFood();

        EventManager.TriggerPumpkinGrows();
    }

    void ResetWater()
    {
        waterTimer = Random.Range(MIN_RESOURCE_RESET, MAX_RESOURCE_RESET);
    }
    
    void ResetFood()
    {
        foodTimer = Random.Range(MIN_RESOURCE_RESET, MAX_RESOURCE_RESET);
    }

    void UpdateLargeState()
    {
        waterTimer -= Time.deltaTime;
        foodTimer -= Time.deltaTime;
        UpdateAwakeState();
        CheckAttack();
    }

    //Running into a bit of redundant name syndrome
    void UpdateAwakeState()
    {
        needsWater = waterTimer < AWAKE_TIMER_THRESHOLD;
        needsFood = foodTimer < AWAKE_TIMER_THRESHOLD;
        if (needsFood || needsWater)
        {
            animator.SetBool("Awake", true);
        }
        else
        {
            animator.SetBool("Awake", false);
        }
    }

    void CheckAttack()
    {
        if (waterTimer < 0f || foodTimer < 0f)
        {
            Attack();
        }
    }

    void Attack()
    {
        if (ResourceManager.RemoveCowDogPig())
        {
            ResetFood();
            ResetWater();
        }
        else
        {
            //Game Over!
        }
    }

    //// Update is called once per frame
    //void Update()
    //{
    //    base.Update();
    //    sleepWakeTimer -= Time.deltaTime;
    //    if(sleepWakeTimer <= 0f)
    //    {
    //        if (awake)
    //        {
    //            animator.SetTrigger("FallAsleep");
    //            awake = false;
    //        }
    //        else
    //        {
    //            animator.SetTrigger("WakeUp");
    //            awake = true;
    //        }
    //        sleepWakeTimer = CYCLE_TIME;
    //    }
    //}
}
