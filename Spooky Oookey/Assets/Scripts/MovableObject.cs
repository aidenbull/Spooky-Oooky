using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : MonoBehaviour
{
    //Only going to use box colliders, will probably only use them for static objects
    //Really only doing this because we're going for an isometric view and will need to account for diagonal collisions
    BoxCollider2D boxCollider;

    // Start is called before the first frame update
    protected void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    protected void Move(Vector2 direction)
    {
        int layerMask = LayerMask.GetMask("wall");
        RaycastHit2D collisionHit = Physics2D.BoxCast(transform.position, transform.localScale, transform.rotation.z, direction, direction.magnitude, layerMask);
        if(collisionHit)
        {
            if(Vector2.Dot(collisionHit.transform.position - transform.position, direction) > 0)
            {
                Debug.Log(collisionHit.normal);
                direction = Vector2.zero;
            }
        }
        //Just for conversion, because I don't know a more elegant way
        Vector3 movement = direction;
        transform.position += movement;
    }
}
