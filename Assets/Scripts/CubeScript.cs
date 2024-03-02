using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    [SerializeField] private GameObject line;
    private LineRenderer lineRenderer;
    [SerializeField] private GameObject selectVectorsScreen;
    [SerializeField] private GameObject glow;
    [SerializeField] private GameUI gameUI;

    private bool CubeSelected = false, SelectedAD = false, SelectedWS = false;
    
    Vector3 moveAD = new(0,0,0);
    Vector3 moveWS = new(0,0,0);
    Vector3 moveDir = Vector3.zero;

    void Start()
    {
        gameUI.UpdateTextAD(MakeString(moveAD));
        gameUI.UpdateTextWS(MakeString(moveWS));
        gameUI = GetComponent<GameUI>();
        lineRenderer = line.GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (CubeSelected)
        {
            glow.SetActive(true); 
            MoveCube();

        } else 
        {
            glow.SetActive(false);
        }
    }

    public void OnMouseDown()
    {
        CubeSelected = !CubeSelected;
    }

    void MoveCube()
    {
        if (Input.GetKeyDown(KeyCode.A)) moveDir -= moveAD;
        if (Input.GetKeyUp(KeyCode.A)) moveDir += moveAD;
        if (Input.GetKeyDown(KeyCode.D)) moveDir += moveAD;
        if (Input.GetKeyUp(KeyCode.D)) moveDir -= moveAD;

        if (Input.GetKeyDown(KeyCode.W)) moveDir += moveWS;
        if (Input.GetKeyUp(KeyCode.W)) moveDir -= moveWS;
        if (Input.GetKeyDown(KeyCode.S)) moveDir -= moveWS;
        if (Input.GetKeyUp(KeyCode.S)) moveDir += moveWS;

        transform.position += moveDir * 5f * Time.deltaTime;
    }

    public void SelectAD()
    {
        SelectedAD = !SelectedAD;
        if (SelectedWS) SelectedWS = false;
    }

    public void SelectWS()
    {
        SelectedWS = !SelectedWS;
        if (SelectedAD) SelectedAD = false;
    }

    public void AddX()
    {
        if (!CubeSelected) 
        {
            if (SelectedAD)
            {
                moveAD.x++;
                gameUI.UpdateTextAD(MakeString(moveAD));
            } 
                
            if (SelectedWS)
            {
                moveWS.x++;
                gameUI.UpdateTextWS(MakeString(moveWS));
            }
        }
    }

    public void SubtractX()
    {
        if (!CubeSelected)
        {
            if (SelectedAD)
            {
                moveAD.x--;
                gameUI.UpdateTextAD(MakeString(moveAD));
            } 
                
            if (SelectedWS)
            {
                moveWS.x--;
                gameUI.UpdateTextWS(MakeString(moveWS));
            }
        }
    }
    
    public void AddY()
    {
        if (!CubeSelected)
        {
            if (SelectedAD)
            {
                moveAD.z++;
                gameUI.UpdateTextAD(MakeString(moveAD));
            } 
                
            if (SelectedWS)
            {
                moveWS.z++;
                gameUI.UpdateTextWS(MakeString(moveWS));
            }
        }
    }

    public void SubtractY()
    {
        if (!CubeSelected)
        {
            if (SelectedAD)
            {
                moveAD.z--;
                gameUI.UpdateTextAD(MakeString(moveAD));
            } 
                
            if (SelectedWS)
            {
                moveWS.z--;
                gameUI.UpdateTextWS(MakeString(moveWS));
            }
        }
    }

    string MakeString(Vector3 v)
    {
        return "(" + v.x + ", " + v.z + ")";
    }
}