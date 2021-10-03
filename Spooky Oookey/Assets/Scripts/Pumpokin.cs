using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pumpokin : SpookyObject
{
    Animator animator;

    float sleepWakeTimer;
    bool awake;

    float CYCLE_TIME = 5f;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        sleepWakeTimer = CYCLE_TIME;
        awake = false;
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
        sleepWakeTimer -= Time.deltaTime;
        if(sleepWakeTimer <= 0f)
        {
            if (awake)
            {
                animator.SetTrigger("FallAsleep");
                awake = false;
            }
            else
            {
                animator.SetTrigger("WakeUp");
                awake = true;
            }
            sleepWakeTimer = CYCLE_TIME;
        }
    }
}
