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
    public IntVariable points;
    public TaskSO firstMoveTask;
    public TaskSO firstCollisionTask;
    public TaskSO secondCollisionTask;
    public TaskSO clickPlayableTask;
    public TaskSO lockedVectorsTask;
    public GameEvent onTaskComplete;
    public UnityEvent isClicked;
    public UnityEvent firstMove;
    public UnityEvent sphereCollision;

    private bool isSelected = false;

    Vector3 MoveV {
        get { return moveVectors.V.Vec3; }
        set { moveVectors.V.Vec3 = value; }
    }
    Vector3 MoveW {
        get { return moveVectors.W.Vec3; }
        set { moveVectors.W.Vec3 = value; }
    }
    Vector3 MoveU {
        get { return moveVectors.U.Vec3; }
        set { moveVectors.U.Vec3 = value; }
    }

    Vector3 moveDir;

    void Start()
    {
        points.i = 0;
    }

    void Update()
    {
        if (isSelected)
        {
            glow.SetActive(true); 
            MoveCube();
        } 
        else 
            glow.SetActive(false);

        if (Input.GetKey(KeyCode.O)) ResetPosition();
    }

    public void OnMouseDown()
    {
        isSelected = !isSelected;
        if (clickPlayableTask.IsActive && isSelected) isClicked?.Invoke();
    }

    void MoveCube()
    {
        if (firstMoveTask.IsActive && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))) firstMove?.Invoke();

        moveDir = Vector3.zero;
        if (Input.GetKey(KeyCode.A)) moveDir = -1 * MoveV;
        if (Input.GetKey(KeyCode.D)) moveDir = MoveV;     
        if (Input.GetKey(KeyCode.W)) moveDir = MoveW;
        if (Input.GetKey(KeyCode.S)) moveDir = -1 * MoveW;
        if (Input.GetKey(KeyCode.Space)) moveDir = 1 * MoveU;
        if (Input.GetKey(KeyCode.LeftShift)) moveDir = -1* MoveU;

        transform.position += moveDir * 1f * Time.deltaTime;
    }

    public void StartVectorW()
    {
        MoveW = new Vector3(0, 0, 3);
    }

    public void SetLockedVectors()
    {
        MoveV = new Vector3(3,0,1);
        MoveW = new Vector3(3,0,2);
    }

    public void Get3DmoveVectors()
    {
        MoveV = new Vector3(-5,0,0);
        MoveW = new Vector3(0,0,-5);
        MoveU = new Vector3(0,5,0);
    }

    public void SetPosition3D()
    {
        transform.position = new Vector3(5,5,5);
    }

    public void ResetPosition()
    {
        transform.position = Vector3.zero;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Point")) 
        {
            sphereCollision?.Invoke();
            if (firstCollisionTask.IsActive || secondCollisionTask.IsActive || lockedVectorsTask.IsActive)
                onTaskComplete.Raise();
        }
    }
}