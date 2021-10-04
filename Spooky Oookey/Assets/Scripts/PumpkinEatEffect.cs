using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PumpkinEatEffect : MonoBehaviour
{

    public delegate void EatCallback();
    EatCallback callback;

    public float EffectDuration = 3.5f;
    float effectTimer;

    Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void Init(EatCallback callback)
    {
        this.callback = callback;
    }

    public void Eat()
    {
        animator.SetTrigger("Eat");
        effectTimer = EffectDuration;
    }

    // Update is called once per frame
    void Update()
    {
        effectTimer -= Time.deltaTime;
        if (effectTimer < 0f)
        {
            callback();
        }
    }
}
