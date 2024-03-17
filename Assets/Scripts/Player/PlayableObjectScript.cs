using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Events;

public class PlayableObjectScript : MonoBehaviour
{
    [SerializeField] private GameObject glow; 
    public MoveVectors moveVectors;
    public UnityEvent isClicked;

    private bool isSelected = false;

    Vector3 MoveV {
        get { return moveVectors.V.Vec3; }
        set { moveVectors.V.Vec3 = value; }
    }
    Vector3 MoveW {
        get { return moveVectors.W.Vec3; }
        set { moveVectors.W.Vec3 = value; }
    }

    Vector3 moveDir;

    void Start()
    {
    }

    void Update()
    {
        if (isSelected)
        {
            glow.SetActive(true); 
            MoveCube();
            isClicked?.Invoke();

        } else 
        {
            glow.SetActive(false);
        }
    }

    public void OnMouseDown()
    {
        isSelected = !isSelected;
        isClicked?.Invoke();
    }

    void MoveCube()
    {
        moveDir = Vector3.zero;
        if (Input.GetKey(KeyCode.A)) moveDir = -1 * MoveV;
        if (Input.GetKey(KeyCode.D)) moveDir = MoveV;     
        if (Input.GetKey(KeyCode.W)) moveDir = MoveW;
        if (Input.GetKey(KeyCode.S)) moveDir = -1 * MoveW;

        transform.position += moveDir * 1f * Time.deltaTime;
    }
}