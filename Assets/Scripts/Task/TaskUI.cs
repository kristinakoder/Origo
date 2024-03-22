using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TaskUI : MonoBehaviour
{
    public GameObject textPrefab;
    public AllTasks allTasks;
    GameObject ny;
    TextMeshProUGUI textMeshPro;

    void Start()
    {
        ny = Instantiate(textPrefab, transform); 
        ny.transform.localPosition = new Vector3(-100, -100, 0f); 
        textMeshPro = ny.GetComponent<TextMeshProUGUI>();  
        ShowActiveTask(allTasks.zero);
    }

    //skal kjøres når en task blir SetActive
    public void ShowActiveTask(TaskSO task)
    {
        textMeshPro.text = task.Description; 
    }
}