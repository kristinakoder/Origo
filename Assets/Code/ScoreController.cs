using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class ScoreController : MonoBehaviour
{
    public IntVariable score;
    public IntVariable scoreThreshold;
    TextMeshProUGUI textMeshPro;
    public GameEvent onScoreThresholdReached;
    public GameEvent onTaskComplete;
    public UnityEvent onEnter3D;
    
    void Start()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (score.i == scoreThreshold.i)
            onScoreThresholdReached?.Raise();

        if (score.i == 14)
            onEnter3D?.Invoke();
            
        if (score.i == 20)
            onTaskComplete?.Raise();
    }

    public void UpdateScore()
    {
        textMeshPro.text = "Poengsum: " + score.i;
    }
}