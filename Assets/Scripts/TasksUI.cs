using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TasksUI : MonoBehaviour
{
    //skal vise tasks som er aktive
    //skal oppdatere når det er nytt
    public GameObject textPrefab;
    public List<TaskSO> objectives;
    GameObject ny;
    TextMeshProUGUI textMeshPro;

    void Start()
    {
        ny = Instantiate(textPrefab, transform); 
        ny.transform.localPosition = new Vector3(-100, -100, 0f); 
        textMeshPro = ny.GetComponent<TextMeshProUGUI>();  
        foreach (TaskSO objSO in objectives)
        {
            objSO.IsActive = false;
            objSO.IsCompleted = false;
        }
        objectives[0].IsActive = true;
        ShowObjective();
    }

    public void ShowObjective()
    {
        foreach (TaskSO objSO in objectives)
        {
            if (objSO.IsActive && !objSO.IsCompleted)
            {           
                textMeshPro.text = objSO.Description;
            }
        }
    }
}