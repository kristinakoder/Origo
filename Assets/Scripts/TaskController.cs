using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskController : MonoBehaviour
{
    [SerializeField] private IntVariable collisionCount;
    [SerializeField] private AllTasks allTasks;
    [SerializeField] private GameEvent onCollisionTask2D, onCollisionTask3D, onHinderTask, onLinearIndependenceTask;
    [SerializeField] private BoolVariable is3D, hindertask;
    [SerializeField] private MoveVectors moveVectors;
    [SerializeField] private GameObject vectorInputController;
    private VectorInputController vectorInputControllerScript;
    public GameObject endScreen;
    public IntVariable score;
    public TextMeshProUGUI scoreText;



    void Start()
    {
        collisionCount.Reset();
        allTasks.Reset();
        vectorInputControllerScript = vectorInputController.GetComponent<VectorInputController>();
    }

    void Update()
    {
        if (collisionCount.i == 0)
        {
            allTasks.tasks[3].IsActive = false;
            allTasks.tasks[0].IsActive = true;
            collisionCount.Increment();
            is3D.SetFalse();
            hindertask.SetFalse();
            moveVectors.ResetVectors();
            vectorInputControllerScript.ResetButtonText();
            onCollisionTask2D?.Raise();
        }
        if (collisionCount.i == 4)
        {
            allTasks.tasks[0].IsActive = false;
            allTasks.tasks[1].IsActive = true;
            collisionCount.Increment();
            is3D.SetTrue();
            hindertask.SetFalse();
            moveVectors.ResetVectors();
            vectorInputControllerScript.ResetButtonText();
            onCollisionTask3D?.Raise();
        }
        if (collisionCount.i == 8)
        {
            allTasks.tasks[1].IsActive = false;
            allTasks.tasks[2].IsActive = true;
            collisionCount.Increment();
            is3D.SetTrue();
            hindertask.SetFalse();
            moveVectors.ResetVectors(); 
            vectorInputControllerScript.ResetButtonText();
            onLinearIndependenceTask?.Raise();
        }
        if (collisionCount.i == 10)
        {
            allTasks.tasks[2].IsActive = false;
            allTasks.tasks[3].IsActive = true;
            collisionCount.Increment();
            is3D.SetFalse();
            hindertask.SetTrue();
            moveVectors.ResetVectors();
            vectorInputControllerScript.ResetButtonText();
            onHinderTask?.Raise();
        }
        if (collisionCount.i >= 14)
            endScreen.SetActive(true);
            scoreText.text = "Poengsum: " + score.i;
    }
}