using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{
    int quadrant;
    public GameObject playable;

    void Start()
    {
        NewPosition();
    }
    /// <summary>
    /// Set the position of the point to a new random position, that is not in the same quadrant as the player.
    /// </summary>
    public void NewPosition()
    {
        quadrant = getQuadrant();

        int newQuadrant;
        
        do { newQuadrant = Random.Range(1, 5);
        } while (newQuadrant == quadrant);
        
        transform.position = newPosition(newQuadrant);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    int getQuadrant()
    {
        if (transform.position.x <= 0 && transform.position.z <= 0)
            return 1;
        else if (transform.position.x > 0 && transform.position.z <= 0)
            return 2;
        else if (transform.position.x > 0 && transform.position.z > 0)
            return 3;
        else
            return 4;
    }

    public void SetPosition()
    {
        transform.position = new Vector3(2, 0.02f, -1);
    }

    Vector3 newPosition(int quadrant)
    {            
        int xPos, yPos;

        xPos = Random.Range(0, 10);
        yPos = Random.Range(0, 10);
        
        switch(quadrant)
        {
            case 1: return new Vector3(-xPos, 0.02f, -yPos);
            case 2: return new Vector3(xPos, 0.02f, -yPos);
            case 3: return new Vector3(xPos, 0.02f, yPos);
            case 4: return new Vector3(-xPos, 0.02f, yPos);
            default: return new Vector3(-7, 0.02f, -3);
        }
    }
}