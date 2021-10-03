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
            direction = Project2D(direction, Rotate2D(collisionHit.normal, Mathf.PI / 2));
        }
        //Just for conversion, because I don't know a more elegant way
        Vector3 movement = direction;
        transform.position += movement;
    }

    Vector2 Rotate2D(Vector2 toRotate, float radianAngle)
    {
        float newX = toRotate.x * Mathf.Cos(radianAngle) - toRotate.y * Mathf.Sin(radianAngle);
        float newY = toRotate.x * Mathf.Sin(radianAngle) + toRotate.y * Mathf.Cos(radianAngle);
        return new Vector2(newX, newY);
    }

    Vector2 Project2D(Vector2 a, Vector2 b)
    {
        Vector2 projectedVector = (Vector2.Dot(a, b) / Vector2.Dot(b, b)) * b;
        return projectedVector;
    }
}
