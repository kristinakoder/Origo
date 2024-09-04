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
        if (is3D.b) NewPosition3D();  
        else NewPosition2D(); 
    }
    
    /// <summary>
    /// Sets the posistion of the hinder between playable and new point.
    /// </summary>
    public void SetHinderPosition() => hinder.transform.position = (transform.position + playablePosition.Vec3) / 2;

    /// <summary>
    /// Set the position of the point to a new random position for 2D, that is not in the same quadrant as the player.
    /// </summary>
    public void NewPosition2DInDifferentQuadrant()
    {
        Vector3 newPos = Random2DVector();

        bool sameQuadrant = 
            transform.position.x > 0 == newPos.x > 0
            && transform.position.z > 0 == newPos.z > 0;

        if (sameQuadrant)
        {
            if (Random.Range(0,2) == 0) newPos.x *= -1;
            else newPos.z *= -1;
        }
        
        transform.position = newPos;
        pointPosition.Vec3 = transform.position;
    }

    /// <summary>
    /// Sets the point to a random new position.
    /// </summary>
    public void NewPosition2D()
    {
        Vector3 newPos;
        do { newPos = Random2DVector();
        } while (newPos == transform.position || (newPos.x == 0 && newPos.z == 0));
        transform.position = Random2DVector();
        pointPosition.Vec3 = transform.position;
    }

    public void NewPosition3D()
    {
        transform.position = new Vector3(Random.Range(2, 10), Random.Range(2, 5), Random.Range(-9, 0));
        pointPosition.Vec3 = transform.position;
    }

    private Vector3 Random2DVector()
    {
        return new Vector3(Random.Range(-9, 10), 0.02f, Random.Range(-9, 10));
    }
}