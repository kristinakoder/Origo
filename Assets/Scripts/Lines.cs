using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lines : MonoBehaviour
{
    private LineRenderer lineRenderer; 
    private GameObject origo;
    [SerializeField] private GameObject line;

    private Vector3[] points = { new Vector3(-10, 0, 0), new Vector3(10, 0, 0) };

    void Start()
    {
        lineRenderer = line.GetComponent<LineRenderer>();
        for (int i = -8; i < 9; i+=2)
        {
            points[0].z = points[1].z = i;

            lineRenderer.SetPositions(points);
            Instantiate(line, transform.position, transform.rotation);
        }
        points[0].z = -10;
        points[1].z = 10;
        
        for (int i = -8; i < 9; i+=2)
        {
            points[0].x = points[1].x = i;

            lineRenderer.SetPositions(points);
            Instantiate(line, transform.position, transform.rotation);
        }
    }

    void Update()
    {

    }


}