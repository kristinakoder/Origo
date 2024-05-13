using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointController : MonoBehaviour
{
    //Maybe find a way to maximize and minimize distance to playable?
    [SerializeField] private Vector3Variable pointPosition;
    [SerializeField] private  Vector3Variable playablePosition;
    [SerializeField] private  GameObject hinder;
    [SerializeField] private  BoolVariable is3D;
    
    int quadrant;

    void Start()
    {
        is3D.b = false; 
        NewPosition();
        pointPosition.Vec3 = transform.position;
    }

    public void NewPosition()
    {
        if (is3D.b)
        {
            NewPosition3D();
        }
        else
        {
            NewPosition2D();
        }
    }

    /// <summary>
    /// Set the position of the point to a new random position for 2D, that is not in the same quadrant as the player.
    /// </summary>
    public void NewPosition2D()
    {
        quadrant = getQuadrant();

        int newQuadrant;
        
        do { newQuadrant = Random.Range(1, 5);
        } while (newQuadrant == quadrant);
        
        pointPosition.Vec3 = transform.position = newPosition(newQuadrant);
    }

    public void SetHinderPosition() => hinder.transform.position = (transform.position + playablePosition.Vec3) / 2;

    /// <summary>
    /// Get the quadrant of the point.
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
            default: return new Vector3(-xPos, 0.02f, yPos);
        }
    }

    public void NewPosition3D()
    {
        pointPosition.Vec3 = transform.position = new Vector3(Random.Range(2, 10), Random.Range(2, 5), Random.Range(-9, -1));
    }
}