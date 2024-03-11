using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Objectives : MonoBehaviour
{
    [SerializeField] GameObject textPrefab;

    int antall = 0;

    void Start()
    {
        AddObjective("Trykk på kuben");
        //AddObjective("Du må velge et negativt tall i en av dem");
        //AddObjective("Du kan kun bruke hver av dem en gang");
    }

    void AddObjective(string description)
    {
        GameObject ny = Instantiate(textPrefab, transform);     
        ny.transform.localPosition = new Vector3(-100, -100 - (antall * 90), 0f);
        TextMeshProUGUI textMeshPro = ny.GetComponent<TextMeshProUGUI>();
        textMeshPro.text = description;
        antall++;
    }
}