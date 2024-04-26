using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIController : MonoBehaviour
{
    public GameObject menuScreen;
    public GameObject gameUI;

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            menuScreen.SetActive(!menuScreen.activeSelf);
            gameUI.SetActive(!menuScreen.activeSelf);
        }        
    }
}