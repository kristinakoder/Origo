using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class VectorInput : MonoBehaviour
{
    [SerializeField] CubeScript cube;
    LineRenderer lineRendererAD;
    LineRenderer lineRendererWS;
    Vector3[] pointsAD = new Vector3[] { new Vector3(0,0.05f,0), new Vector3(0,0.05f,0)};
    Vector3[] pointsWS = new Vector3[] { new Vector3(0,0.05f,0), new Vector3(0,0.05f,0)};
    bool ADXchanged = false, ADYchanged = false;
    public Objectives tasks;

    void Start()
    {
        lineRendererAD = cube.lineAD.GetComponent<LineRenderer>();
        lineRendererWS = cube.lineWS.GetComponent<LineRenderer>();
        
        Instantiate(cube.lineAD, cube.transform.position, cube.transform.rotation);   
        Instantiate(cube.lineWS, cube.transform.position, cube.transform.rotation); 
    }

    public void GetADX(string input) 
    {
        int.TryParse(input, out int a);
        cube.moveAD.x = a;
        UpdateVectorAD();
        ADXchanged = true;
        if (ADXchanged && ADYchanged && tasks.tasks[1].isActive)
        { 
            tasks.tasks[1].isActive = false;
            tasks.tasks[2].isActive = true;
            tasks.UpdateTask();
        }
    }

    public void GetADY(string input)
    {
        int.TryParse(input, out int a);
        cube.moveAD.z = a;
        UpdateVectorAD();
        ADYchanged = true;
        if (ADXchanged && ADYchanged && tasks.tasks[1].isActive)
        { 
            tasks.tasks[1].isActive = false;
            tasks.tasks[2].isActive = true;
            tasks.UpdateTask();
        }
    }

    public void UpdateVectorAD()
    {
        pointsAD[0].x = cube.transform.position.x;
        pointsAD[0].z = cube.transform.position.z;
        pointsAD[1].x = cube.transform.position.x + cube.moveAD.x;
        pointsAD[1].z = cube.transform.position.z + cube.moveAD.z;
        lineRendererAD.SetPositions(pointsAD); 
    }

    public void GetWSX(string input)
    {
        int.TryParse(input, out int a);
        cube.moveWS.x = a;
        UpdateVectorWS();
    }

    public void GetWSY(string input)
    {   
        int.TryParse(input, out int a);
        cube.moveWS.z = a;
        UpdateVectorWS();
    }
        
    public void UpdateVectorWS()
    {
        pointsWS[0].x = cube.transform.position.x;
        pointsWS[0].z = cube.transform.position.z;
        pointsWS[1].x = cube.transform.position.x + cube.moveWS.x;
        pointsWS[1].z = cube.transform.position.z + cube.moveWS.z;
        lineRendererWS.SetPositions(pointsWS); 
    }
}