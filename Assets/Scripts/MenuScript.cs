using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{   
    public IntVariable score;
    public TextMeshProUGUI scoreText;
    public GameObject endScreen;

    public void NewGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetScoreText()
    {
        scoreText.text = "Score: " + score.i;
    }

    public void EndGame()
    {
        endScreen.SetActive(true);
        SetScoreText();
    }
}