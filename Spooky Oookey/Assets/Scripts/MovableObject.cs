using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovableObject : SpookyObject
{
    /*
     * Designed for objects that will move and handle collision. Ended up just being the player
     */

    //Only going to use box colliders, will probably only use them for static objects
    //Really only doing this because we're going for an isometric view and will need to account for diagonal collisions
    BoxCollider2D boxCollider;

    protected delegate void CollisionCallback(Collider2D collider);
    //CollisionCallback callback;

    // Start is called before the first frame update
    protected void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
    }

    //protected void SetCollisionDelegate(CollisionCallback childCallback)
    //{
    //    callback = childCallback;
    //}

    //OOooooops this collision only accounts for one colliding body, so if the player is hugging a wall, they can walk through every other wall
    protected void Move(Vector2 direction, int collisionMask = 0, int triggerMask = 0, CollisionCallback callback = null)
    {
        if (collisionMask == 0) collisionMask = LayerMask.GetMask("wall");

        Vector3 colliderOffset = boxCollider.offset;
        Vector3 colliderSize = boxCollider.size;

        RaycastHit2D collisionHit = Physics2D.BoxCast(transform.position + colliderOffset, colliderSize, transform.rotation.z, direction, direction.magnitude, collisionMask + triggerMask);
        if(collisionHit)
        {
            //Code referenced from https://answers.unity.com/questions/50279/check-if-layer-is-in-layermask.html
            //Project movement along the colliding surface if the colliding object is in our collision mask
            if (collisionMask == (collisionMask | (1 << collisionHit.collider.gameObject.layer)))
            {
                //Has minor issue when colliding on corner of box unfortunately, happens infrequently enough that im just leaving it
                direction = Utilities.Project2D(direction, Utilities.Rotate2D(collisionHit.normal, Mathf.PI / 2));
            }
            //Handle callbacks if they exist
            if (callback != null) callback(collisionHit.collider);
        }
        //Just for conversion, because I don't know a more elegant way
        Vector3 movement = direction;
        transform.position += movement;
    }
}
