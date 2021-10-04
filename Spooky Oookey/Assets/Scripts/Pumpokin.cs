using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public GameObject ChildTrigger;
    ChildObjectTrigger childTriggerScript;
    public bool playerInRange = false;

    public GameObject FoodButton;
    public GameObject WaterButton;
    PumpkinButton foodButton;
    PumpkinButton waterButton;

    public GameObject rainEffect;
    public GameObject poopEffect;

    void Start()
    {
        animator = GetComponent<Animator>();
        currGrowth = GrowthState.Small;

        childTriggerScript = ChildTrigger.GetComponent<ChildObjectTrigger>();
        childTriggerScript.Init(PumpkinTriggerEnter, PumpkinTriggerExit);

        foodButton = FoodButton.GetComponent<PumpkinButton>();
        waterButton = WaterButton.GetComponent<PumpkinButton>();
        foodButton.Init(TryFeedPumpkin);
        waterButton.Init(TryWaterPumpkin);
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

    void TryWaterPumpkin()
    {
        if (ResourceManager.DecrementWater())
        {
            ResetWater();
            EventManager.TriggerInteract();
            GameObject rain = Instantiate(rainEffect);
            rain.transform.position = transform.position + new Vector3(0f, 0.2f, -1f);
        }
        else
        {
            EventManager.TriggerNotEnoughWater();
        }
    }

    void TryFeedPumpkin()
    {
        if (ResourceManager.DecrementPoop())
        {
            ResetFood();
            EventManager.TriggerInteract();
        }
        else
        {
            EventManager.TriggerNotEnoughPoop();
        }
    }

    void UpdateLargeState()
    {
        if (!waitingOnAttackAnim)
        {
            waterTimer -= Time.deltaTime;
            foodTimer -= Time.deltaTime;
            UpdateAwakeState();
            CheckAttack();
        }
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
        SetFoodActive(needsFood);
        SetWaterActive(needsWater);
    }

    void CheckAttack()
    {
        if (waterTimer < 0f || foodTimer < 0f)
        {
            Attack();
        }
    }

    bool waitingOnAttackAnim = false;
    void Attack()
    {
        animator.SetTrigger("Attack");
        waitingOnAttackAnim = true;
        if (ResourceManager.RemoveCowDogPig())
        {
            ResetFood();
            ResetWater();
        }
        else
        {
            //Game Over!
            Scene scene = SceneManager.GetActiveScene(); 
            SceneManager.LoadScene(scene.name);
        }
    }

    void AttackAnimCallback()
    {
        waitingOnAttackAnim = false;
    }

    void ShowButtons(bool visible)
    {
        if (visible)
        {
            foodButton.Show();
            waterButton.Show();
        }
        else
        {
            foodButton.Hide();
            waterButton.Hide();
        }
    }

    void SetFoodActive(bool active)
    {
        foodButton.SetActive(active);
    }

    void SetWaterActive(bool active)
    {
        waterButton.SetActive(active);
    }

    private void PumpkinTriggerEnter(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            ShowButtons(true);
        }
    }

    private void PumpkinTriggerExit(Collider2D collider)
    {
        if (collider.CompareTag("Player"))
        {
            ShowButtons(false);
        }
    }

}
