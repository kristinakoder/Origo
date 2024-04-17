using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{    
    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}