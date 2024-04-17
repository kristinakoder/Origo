using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreController : MonoBehaviour
{
    public IntVariable score;
    TextMeshProUGUI textMeshPro;
    
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
        score.i = 0;
    }

    public void UpdateScore()
    { textMeshPro.text = "Poengsum: " + score.i; }
}