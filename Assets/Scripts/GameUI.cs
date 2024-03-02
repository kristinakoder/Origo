using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TextVectorAD;  
    [SerializeField] private TextMeshProUGUI TextVectorWS;

    public void UpdateTextAD(string vectorText)
    {
        TextVectorAD.text = vectorText;
    }
    
    public void UpdateTextWS(string vectorText)
    {
        TextVectorWS.text = vectorText;
    }

    public void UpdateADx()
    {
        
    }
}