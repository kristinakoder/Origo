using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class VectorInputController : MonoBehaviour
{
    public List<TMP_InputField> vectorInputs;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.V))
            vectorInputs[0].Select();
        
        if (Input.GetKeyDown(KeyCode.Tab))
            for (int i = 0; i < vectorInputs.Count; i++)
                if (vectorInputs[i].isFocused)
                {
                    if (i == vectorInputs.Count - 1 || !vectorInputs[i + 1].IsActive())
                        vectorInputs[0].Select();
                    else
                        vectorInputs[i + 1].Select();
                    break;
                }
    }

    public void ResetInputField()
    {
        foreach(TMP_InputField input in vectorInputs)
        {
            input.text = "0";
        }   
    }

    public void DeselectSelected()
    {
        foreach(TMP_InputField input in vectorInputs)
        {
            if (input.isFocused)
                input.DeactivateInputField();
        }
    }
}