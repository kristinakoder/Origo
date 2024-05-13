using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Services.Leaderboards;
using Unity.VisualScripting;
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
    [SerializeField] private BoolVariable is3D, hinderTask;
    [SerializeField] private GameObject continueButton;

    [SerializeField] private TextMeshProUGUI vectorTextV, vectorTextW, vectorTextU, buttonTextVX, buttonTextVY, 
        buttonTextVZ, buttonTextWX, buttonTextWY, buttonTextWZ, buttonTextUX, buttonTextUY, buttonTextUZ, 
        buttonChooseU0, buttonChooseU1, buttonChooseU2, buttonChooseU3, bracketTextV, bracketTextW, bracketTextU;

    List<Vector3> choices;
    int buttonSelected = -1;

    void Start()
    {
        moveVectors.ResetVectors();
    }

    void Update()
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

    public void LockInputButtons()
    {
        foreach (Button button in vectorButtons)
        {
            button.interactable = false;
        }
    }

    public void UnlockInputButtons()
    {
        foreach (Button button in vectorButtons)
        {
            button.interactable = true;
        }
    }

    /// <summary>
    /// Sets vectors V and W to random 2D vectors that are linear independent.
    /// </summary>
    public void SetTwoRandom2DVectors()
    {
        if (hinderTask.b)
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
    }

    public void ResetButtonText()
    {
        buttonTextVX.text = "0";
        buttonTextVY.text = "0";
        buttonTextVZ.text = "0";
        buttonTextWX.text = "0";
        buttonTextWY.text = "0";
        buttonTextWZ.text = "0";
        buttonTextUX.text = "0";
        buttonTextUY.text = "0";
        buttonTextUZ.text = "0";
    }

    public void ChooseVectorU(int i)
    {
        switch(i)
        {
            case 0:
                moveVectors.U.Vec3 = choices[0];
                buttonTextUX.text = "" + choices[0].x;
                buttonTextUY.text = "" + choices[0].z;
                buttonTextUZ.text = "" + choices[0].y;
                break;
            case 1:
                moveVectors.U.Vec3 = choices[1];
                buttonTextUX.text = "" + choices[1].x;
                buttonTextUY.text = "" + choices[1].z;
                buttonTextUZ.text = "" + choices[1].y;
                break;
            case 2:
                moveVectors.U.Vec3 = choices[2];
                buttonTextUX.text = "" + choices[2].x;
                buttonTextUY.text = "" + choices[2].z;
                buttonTextUZ.text = "" + choices[2].y;
                break;
            case 3:
                moveVectors.U.Vec3 = choices[3];
                buttonTextUX.text = "" + choices[3].x;
                buttonTextUY.text = "" + choices[3].z;
                buttonTextUZ.text = "" + choices[3].y;
                break;
            default:
                break;
        }
    }

    private Vector3 GetNormalToPlane(Vector3 a, Vector3 b)
    {
        float x = a.y * b.z - a.z * b.y;
        float y = a.z * b.x - a.x * b.z;
        float z = a.x * b.y - a.y * b.x;
        return new Vector3(x, y, z);
    }

    private float GetAngleBetweenVectors(Vector3 a, Vector3 b)
    {
        return Mathf.Acos(Vector3.Dot(a, b) / (a.magnitude * b.magnitude));
    }  

    /// <summary>
    /// Creates a random 2D vector that doesn't go directly towards the target point, sets it to V and sets 
    /// W to [0, random]. 
    /// </summary>
    public void SetNewVectorVNotDirectlyToPoint()
    {
        Vector3 newVector = CreateRandom2DVector();
        Vector3 vectorToPoint = pointPosition.Vec3 - playablePosition.Vec3;
        if (IsLinearDependent(newVector, vectorToPoint))
            newVector.x *= -1;
        
        moveVectors.V.Vec3 = newVector;
        Vector3 newW = CreateRandom2DVector();
        newW.x = 0;
        moveVectors.W.Vec3 = newW;
        buttonTextVX.text = "" + newVector.x;
        buttonTextVY.text = "" + newVector.z;
        buttonTextWX.text = "0";
        buttonTextWY.text = "" + newW.z;
    }

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

    /// <summary> Creates and returns a Vector3 that is linear dependent on the two given vectors.</summary>
    private Vector3 CreateLinearDependentVector(Vector3 a, Vector3 b)
    {
        if (a.magnitude > b.magnitude) return a - b * Random.Range(1, 4);
        
        else return b - a * Random.Range(1, 4);
    }

    public void RightChoice()
    {
        if (!IsLinearDependent(moveVectors.V.Vec3, moveVectors.W.Vec3, moveVectors.U.Vec3))
        {
            continueButton.SetActive(true);
        }
    }

    /// <summary>
    /// Returns a list of five Vector3. The first vector randomly chosen, 3 of them a linear dependent to the first, 
    /// one is linear independent.
    /// </summary>
    /// <returns></returns>
    public void CreateAndSetVectorChoices()
    {
        moveVectors.V.Vec3 = CreateRandom3DVector();
        moveVectors.W.Vec3 = CreateRandom3DVector();

        while (IsLinearDependent(moveVectors.V.Vec3, moveVectors.W.Vec3))
        {
            moveVectors.W.Vec3 = CreateRandom3DVector();
        }

        buttonTextVX.text = "" + moveVectors.V.Vec3.x;
        buttonTextVY.text = "" + moveVectors.V.Vec3.z;
        buttonTextVZ.text = "" + moveVectors.V.Vec3.y;
        buttonTextWX.text = "" + moveVectors.W.Vec3.x;
        buttonTextWY.text = "" + moveVectors.W.Vec3.z;
        buttonTextWZ.text = "" + moveVectors.W.Vec3.y;

        Vector3 a = CreateLinearDependentVector(moveVectors.V.Vec3, moveVectors.W.Vec3);
        Vector3 b = CreateLinearDependentVector(a, moveVectors.W.Vec3);
        while (b.Equals(a))
        {
            b = CreateLinearDependentVector(a, moveVectors.W.Vec3);
        }
        Vector3 c = CreateLinearDependentVector(a, b);
        while (c.Equals(a) || c.Equals(b))
        {
            c = CreateLinearDependentVector(a, b);
        }
        Vector3 d = CreateRandom3DVector();
        Vector3 n = GetNormalToPlane(a, b);
        float angle = GetAngleBetweenVectors(n, d);

        while (angle > 1)
        {
            d = CreateRandom3DVector();
            angle = GetAngleBetweenVectors(n, d);
        }

        choices = new List<Vector3> {a, b, c, d};

        Shuffle(choices);

        buttonChooseU0.text = "[" + choices[0].x + ", " + choices[0].z + ", " + choices[0].y + "]";
        buttonChooseU1.text = "[" + choices[1].x + ", " + choices[1].z + ", " + choices[1].y + "]";
        buttonChooseU2.text = "[" + choices[2].x + ", " + choices[2].z + ", " + choices[2].y + "]";
        buttonChooseU3.text = "[" + choices[3].x + ", " + choices[3].z + ", " + choices[3].y + "]";
    }

    private void Shuffle(List<Vector3> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            Vector3 temp = list[i];
            int randomIndex = Random.Range(i, list.Count);
            list[i] = list[randomIndex];
            list[randomIndex] = temp;
        }
    }

    public void SetBracketText3D()
    {
        bracketTextV.text = "[       ,       ,       ]";
        bracketTextW.text = "[       ,       ,       ]";
        bracketTextU.text = "[       ,       ,       ]";
    }
        
    public void SetBracketText2D()
    {
        bracketTextV.text = "[       ,       ]";
        bracketTextW.text = "[       ,       ]";
        bracketTextU.text = "[       ,       ]";
    }
    

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