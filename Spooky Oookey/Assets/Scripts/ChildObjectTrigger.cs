using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildObjectTrigger : MonoBehaviour
{
    public float TriggerRadius = 1.5f;
    CircleCollider2D localCollider;

    public delegate void OnTriggerEnter(Collider2D collider);
    public delegate void OnTriggerExit(Collider2D collider);

    OnTriggerEnter triggerEnter;
    OnTriggerExit triggerExit;

    // Start is called before the first frame update
    void Start()
    {
        localCollider = GetComponent<CircleCollider2D>();
        localCollider.radius = TriggerRadius;
    }

    public void Init(OnTriggerEnter enter, OnTriggerExit exit)
    {
        triggerEnter = enter;
        triggerExit = exit;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggerEnter != null) triggerEnter(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (triggerExit != null) triggerExit(collision);
    }
}
