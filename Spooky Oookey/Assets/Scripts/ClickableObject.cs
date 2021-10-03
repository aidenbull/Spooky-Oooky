using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ClickableObject : MonoBehaviour
{
    public virtual void OnClick() { }

    private void OnMouseDown()
    {
        OnClick();
    }
}
