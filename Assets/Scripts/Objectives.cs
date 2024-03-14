using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Objectives : MonoBehaviour
{
    [SerializeField] GameObject textPrefab;
    public List<Task> tasks;
    GameObject ny;
    TextMeshProUGUI textMeshPro;

    int antall = 0;

    void Start()
    {
        foreach(Task t in tasks)
        {
            t.isActive = false;
        }
        tasks[0].isActive = true;
        ny = Instantiate(textPrefab, transform); 
        ny.transform.localPosition = new Vector3(-100, -100 - (antall * 90), 0f);
        textMeshPro = ny.GetComponent<TextMeshProUGUI>();
        //textMeshPro.text = tasks[0].description;
        UpdateTask();
    }

    public void UpdateTask()
    {
        foreach(Task t in tasks)
        {
            if(t.isActive)
            {
                textMeshPro.text = t.description;
            }
        }    
    }
}