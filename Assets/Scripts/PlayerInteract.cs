using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Windows;

public class PlayerInteract : MonoBehaviour
{
    private Camera cam;
    [SerializeField] private float distance = 10;
    [SerializeField] private LayerMask mask;
    private PlayerUI playerUI;
    private InputManager inputManager;
    [SerializeField] private GameObject interactionAction;
    [SerializeField] private CubeInteractable cube;

    void Start()
    {
        cam = GetComponent<PlayerMotor>().cam;
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    void Update()
    {
        cube.MoveCube();
        playerUI.UpdateText("");
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            Interactable interactable = hitInfo.collider.GetComponent<Interactable>();
            if(interactable != null)
            {
                interactable.BaseInteract();
                playerUI.UpdateText(interactable.promtMessage);
                if (inputManager.noGravity.Interact.triggered)
                {
                    interactionAction.SetActive(true);
                }
            }
        }
    }
}