using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Point : Interactable
{
    protected override void Interact()
    {
        Debug.Log("Interacted with " + gameObject.name);
    }

}
