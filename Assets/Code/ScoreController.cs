using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public IntVariable score;
    public IntVariable scoreThreshold;
    TextMeshProUGUI textMeshPro;
    public GameEvent onScoreThresholdReached;
    
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (score.i == scoreThreshold.i)
            onScoreThresholdReached?.Raise();
    }

    public void UpdateScore()
    {
        textMeshPro.text = "Poengsum: " + score.i;
    }
}