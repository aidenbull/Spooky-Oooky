using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClickableObject : MonoBehaviour
{

    //Now that i look at it again, this entire class might be redundant. Not looking into it at the moment tho
    public virtual void OnMouseD() { }
    public virtual void OnMouseU() { }
    public virtual void OnMouseIn() { }
    public virtual void OnMouseOut() { }

    private void OnMouseDown()
    {
        OnMouseD();
    }

    private void OnMouseUp()
    {
        OnMouseU();
    }

    private void OnMouseEnter()
    {
        OnMouseIn();   
    }

    private void OnMouseExit()
    {
        OnMouseOut();
    }
}
