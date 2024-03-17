using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using Unity.VisualScripting;
using UnityEngine;

public class VectorInput : MonoBehaviour
{
    //denne skal håndtere når det blir tasta inn noe i inputBoksene. 
    //tenker et annet script skal tegne vektorene. Heller playableObject hvertfall, hvis ikke et eget.
    public MoveVectors moveVectors;

    float Vx
    {
        get { return moveVectors.V.Vec3.x; }
        set { 
            Vector3 temp = moveVectors.V.Vec3;
            temp.x = value; 
            moveVectors.V.Vec3 = temp;
        }
    }

    //kanskje like lett å bare gjøre dette for hver metode eller lignene. Ikke opprette hver variabel...

    //Hadde vært kjekt med en metode som tar inn input og på en eller annen måte vet hvilken vektor og verdi den skal jobbe med... 
    //Trenger vel et event? Kanskje?
    
    //en input er vx, en vy, en wx og en wy...

    

    public void GetADX(string input) 
    {
        int.TryParse(input, out int a);
    }

    public void GetADY(string input)
    {
        int.TryParse(input, out int a); 
    }

    public void GetWSX(string input)
    {
        int.TryParse(input, out int a);
        
    }

    public void GetWSY(string input)
    {   
        int.TryParse(input, out int a);
        
    }
}