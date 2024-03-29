using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] private GameObject line;

    private Vector3[] points = { new Vector3(-10, 0.03f, 0), new Vector3(10, 0.03f, 0) };

    void Start()
    {
        lineRenderer = line.GetComponent<LineRenderer>();
        DrawLines();
    }

    void DrawLines()
    {
        lineRenderer.startWidth = lineRenderer.endWidth = 0.01f;
        for (int i = -9; i < 10; i++)
        {
            points[0].z = points[1].z = i;
            DrawLine(points);
        }
        points[0].z = -10;
        points[1].z = 10;
        
        for (int i = -9; i < 10; i++)
        {
            points[0].x = points[1].x = i;
            DrawLine(points);
        }
    }
    
    private void DrawLine(Vector3[] points)
    {
        lineRenderer.startWidth = lineRenderer.endWidth = (points[0].x == 0 || points[0].z == 0) ? 0.1f : 0.02f;
        lineRenderer.SetPositions(points);
        Instantiate(line, transform.position, transform.rotation);
    }
}