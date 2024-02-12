using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeInteractable : Interactable
{
    [SerializeField] private GameObject interactionAction;
    [SerializeField] public new Rigidbody rigidbody;

    protected override void Interact()
    {
        promtMessage = "Kuben har posisjon (" + transform.position.x + ", " + transform.position.z + "). Få kuben bort til det andre punktet";
    }

    public void MoveCube()
    {
        if (Input.GetKeyDown(KeyCode.L)) rigidbody.velocity += Vector3.right;
        if (Input.GetKeyUp(KeyCode.L)) rigidbody.velocity = Vector3.zero;
        if (Input.GetKeyDown(KeyCode.J)) rigidbody.velocity += Vector3.left;
        if (Input.GetKeyUp(KeyCode.J)) rigidbody.velocity = Vector3.zero;
    }
}