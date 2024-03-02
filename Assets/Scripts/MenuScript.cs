using UnityEngine;

public class MenuScript : MonoBehaviour
{    
    public void QuitGame()
    {
        Debug.Log("clicked quit");
        Application.Quit();
    }
}