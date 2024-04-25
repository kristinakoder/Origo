using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{   
    void Start()
    {
        gameObject.SetActive(true);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
            gameObject.SetActive(true);
    }

    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}