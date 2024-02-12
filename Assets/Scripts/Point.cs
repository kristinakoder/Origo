using UnityEngine;

public class Point : Interactable
{
    protected override void Interact()
    {
        promtMessage = "(" + transform.position.x + ", " + transform.position.z + ")";
    }
}