using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class VectorInput : MonoBehaviour
{
    //denne skal håndtere når det blir tasta inn noe i inputBoksene. 
    //tenker et annet script skal tegne vektorene. Heller playableObject hvertfall, hvis ikke et eget.
    public PlayableObject playableObject; //skal ikke ha denne? Men må vite hvor den er da....
    LineRenderer lineRendererAD;
    LineRenderer lineRendererWS;
    Vector3[] pointsAD = new Vector3[] { new Vector3(0,0.05f,0), new Vector3(0,0.05f,0)};
    Vector3[] pointsWS = new Vector3[] { new Vector3(0,0.05f,0), new Vector3(0,0.05f,0)};
    [SerializeField] Objectives objectives; //skal ikke ha denne!
    bool ADXchanged = false, ADYchanged = false;

    void Start()
    {
        //lineRendererAD = playableObject.lineAD.GetComponent<LineRenderer>();
        //lineRendererWS = playableObject.lineWS.GetComponent<LineRenderer>();
    }

    public void GetADX(string input) 
    {
        int.TryParse(input, out int a);
        playableObject.moveAD.x = a;
        UpdateVectorAD();
        ADXchanged = true;
        if (ADXchanged && ADYchanged && objectives.objectives[1].IsActive) 
        {
            //dette skal være et event
            objectives.objectives[1].Complete();
            objectives.objectives[2].IsActive = true;
            objectives.ShowObjective();
        }
    }

    public void GetADY(string input)
    {
        int.TryParse(input, out int a);
        playableObject.moveAD.z = a;
        UpdateVectorAD();
        ADYchanged = true;
        if (ADXchanged && ADYchanged && objectives.objectives[1].IsActive) 
        {
            objectives.objectives[1].Complete();
            objectives.objectives[2].IsActive = true;
            objectives.ShowObjective();
        }
    }

    public void UpdateVectorAD()
    {
        //denne skal ikke være her. Heller eget script tror jeg....
        pointsAD[0].x = playableObject.transform.position.x;
        pointsAD[0].z = playableObject.transform.position.z;
        pointsAD[1].x = playableObject.transform.position.x + playableObject.moveAD.x;
        pointsAD[1].z = playableObject.transform.position.z + playableObject.moveAD.z;
        lineRendererAD.SetPositions(pointsAD); 
    }

    public void GetWSX(string input)
    {
        int.TryParse(input, out int a);
        playableObject.moveWS.x = a;
        UpdateVectorWS();
    }

    public void GetWSY(string input)
    {   
        int.TryParse(input, out int a);
        playableObject.moveWS.z = a;
        UpdateVectorWS();
    }
        
    public void UpdateVectorWS()
    {
        pointsWS[0].x = playableObject.transform.position.x;
        pointsWS[0].z = playableObject.transform.position.z;
        pointsWS[1].x = playableObject.transform.position.x + playableObject.moveWS.x;
        pointsWS[1].z = playableObject.transform.position.z + playableObject.moveWS.z;
        lineRendererWS.SetPositions(pointsWS); 
    }
}