using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class VectorInputController : MonoBehaviour
{
    [SerializeField] private List<TMP_InputField> vectorInputs;
    [SerializeField] private List<Button> vectorButtons;
    [SerializeField] private MoveVectors moveVectors;
    [SerializeField] private Vector3Variable pointPosition;
    [SerializeField] private Vector3Variable playablePosition;
    [SerializeField] private BoolVariable is3D;

    [SerializeField] private TextMeshProUGUI vectorTextV, vectorTextW, vectorTextU, buttonTextVX, buttonTextVY, 
        buttonTextVZ, buttonTextWX, buttonTextWY, buttonTextWZ, buttonTextUX, buttonTextUY, buttonTextUZ;

    int buttonSelected = -1;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            buttonSelected++;

            if (buttonSelected >= vectorButtons.Count)
                buttonSelected = 0;

            while(!vectorButtons[buttonSelected].IsActive())
                buttonSelected++;
            
            vectorButtons[buttonSelected].Select();
        }     
    }

    public void ResetInputField()
    {
        foreach(TMP_InputField input in vectorInputs)
        {
            input.text = "0";
        }   
    }

    public void SetRandom3DVectorV() => moveVectors.V.Vec3 = CreateRandom3DVector();

    public void SetRandom3DVectorW() => moveVectors.W.Vec3 = CreateRandom3DVector();

    public void SetRandom3DVectorU() => moveVectors.U.Vec3 = CreateRandom3DVector();

    public void SetRandom2DVectorV() => moveVectors.V.Vec3 = CreateRandom2DVector();

    public void SetRandom2DVectorW() => moveVectors.W.Vec3 = CreateRandom2DVector();

    public void SetRandom2DVectorU() => moveVectors.U.Vec3 = CreateRandom2DVector();

    /// <summary>
    /// Sets vectors V and W to random 2D vectors that are linear independent.
    /// </summary>
    public void SetTwoRandom2DVectors()
    {
        moveVectors.V.Vec3 = CreateRandom2DVector();
        moveVectors.W.Vec3 = CreateRandom2DVector();
        while (IsLinearDependent(moveVectors.V.Vec3, moveVectors.W.Vec3))
        {
            moveVectors.W.Vec3 = CreateRandom2DVector();
        }
        buttonTextVX.text = "" + moveVectors.V.Vec3.x;
        buttonTextVY.text = "" + moveVectors.V.Vec3.z;
        buttonTextWX.text = "" + moveVectors.W.Vec3.x;
        buttonTextWY.text = "" + moveVectors.W.Vec3.z;
    }

    /* NOT WORKING YET: pointPosition is not updated an is the same as playablePosition.
    /// <summary>
    /// Creates a random 2D vector that doesn't go directly towards the target point, sets it to V and sets 
    /// W to [0, random]. 
    /// </summary>
    public void SetNewVectorVNotDirectlyToPoint()
    {
        Vector3 newVector = CreateRandom2DVector();
        Vector3 vectorToPoint = pointPosition.Vec3 - playablePosition.Vec3;
        if (IsLinearDependent2D(newVector, vectorToPoint))
            newVector.x = newVector.x * -1;
        
        moveVectors.V.Vec3 = newVector;
        Vector3 newW = CreateRandom2DVector();
        newW.x = 0;
        moveVectors.W.Vec3 = newW;
        buttonTextVX.text = "" + newVector.x;
        buttonTextVY.text = "" + newVector.z;
        buttonTextWX.text = "0";
        buttonTextWY.text = "" + newW.z;
    }*/

    private int Determinant(Vector3 a, Vector3 b)
    {
        return (int) (a.x * b.z - b.x * a.z);
    }

    private int Determinant(Vector3 a, Vector3 b, Vector3 c)
    {
        return (int) (a.x * (b.y * c.z - b.z * c.y) - a.y * (b.x * c.z - b.z * c.x) + a.z * (b.x * c.y - b.y * c.x));
    }

    private bool IsLinearDependent(Vector3 a, Vector3 b)
    {
        return Determinant(a, b) == 0;
    }

    private bool IsLinearDependent(Vector3 a, Vector3 b, Vector3 c)
    {
        return Determinant(a, b, c) == 0;
    }

    /// <summary>
    /// Creates a random 3D vector
    /// </summary>
    /// <returns></returns>
    private Vector3 CreateRandom3DVector()
    {
        return new Vector3(Random.Range(-10, 11), Random.Range(-10, 11), Random.Range(-10, 11));
    }

    /// <summary>
    /// Creates a Vector for 2D level, where y = 0 and x and z are random
    /// </summary>
    /// <returns></returns>
    private Vector3 CreateRandom2DVector()
    {
        return new Vector3(Random.Range(-10, 11), 0, Random.Range(-10, 11));
    }

    /// <summary>
    /// Creates and returns a vector3 that is linear dependant on the two given vectors.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    private Vector3 CreateLinearDependantVector(Vector3 a, Vector3 b)
    {
        if (a.magnitude > b.magnitude) return a - b * Random.Range(1, 4);
        
        else return b - a * Random.Range(1, 4);
    }

    /// <summary>
    /// Returns a list of five Vector3. The first vector randomly chosen, 3 of them a linear dependent to the first, 
    /// one is linear independent.
    /// </summary>
    /// <returns></returns>
    private List<Vector3> CreateVectorChoices()
    {
        List<Vector3> choices = new List<Vector3>
        {
            CreateRandom3DVector(),
            CreateRandom3DVector()
        };
        choices.Add(CreateLinearDependantVector(choices[0], choices[1]));
        Vector3 a = CreateRandom3DVector();
        while (IsLinearDependent(choices[0], choices[1], a))
        {
            a = CreateRandom3DVector();
        }
        choices.Add(a);

        return choices;
    }

/*
    public void SetVectorText()
    {
        if(is3D.b)
            vectorText.text = "[       ,       ,       ]";
        else 
            vectorText.text = "[       ,       ]";
    }*/

    /// <summary>
    /// Takes in a Vector3 and shortens it if possible.
    /// </summary>
    /// <param name="v"></param>
    /// <returns></returns>
    private Vector3 ShortenVector(Vector3 v)
    {
        //TODO: Make more efficient
        int min = (int) Math.Min(v.x, Math.Min(v.y, v.z));
        for (int i = min; i > 1; i--)
        {
            if (v.x % i == 0 && v.y % i == 0 && v.z % i == 0)
            {
                v.x /= i;
                v.y /= i;
                v.z /= i;
                break;
            }
        }
        return v;
    }
}