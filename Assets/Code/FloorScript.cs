using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorScript : MonoBehaviour
{
    private LineRenderer lineRenderer;
    [SerializeField] private GameObject line;

    private Vector3[] points = { new Vector3(0, 0.03f, 0), new Vector3(10, 0.03f, 0) };

    void Start()
    {
        lineRenderer = line.GetComponent<LineRenderer>();
        DrawLines();
        //DrawLines3D();
    }

    public void DrawLines()
    {
        lineRenderer.startWidth = lineRenderer.endWidth = 0.01f;
        points[0].x = -10;
        for (int i = -9; i < 10; i++)
        {
            points[0].z = points[1].z = i;
            lineRenderer.startWidth = lineRenderer.endWidth = (points[0].z == 0) ? 0.1f : 0.02f;
            DrawLine(points);
        }
        points[0].z = -10;
        points[1].z = 10;
        
        for (int i = -9; i < 10; i++)
        {
            points[0].x = points[1].x = i;
            lineRenderer.startWidth = lineRenderer.endWidth = (points[0].x == 0) ? 0.1f : 0.02f;
            DrawLine(points);
        }
    }

    public void DestroyLines()
    {
        GameObject[] lines = GameObject.FindGameObjectsWithTag("Line");
        foreach (GameObject line in lines)
        {
            Destroy(line);
        }
    }

    public void DrawLines3D()
    {
        lineRenderer = line.GetComponent<LineRenderer>();
        points[0] = new Vector3(0, 0.03f, 0);
        points[1] = new Vector3(10, 0.03f, 0);
        lineRenderer.startWidth = lineRenderer.endWidth = 0.01f;
        for (int i = 0; i < 10; i++)
        {
            points[0].z = points[1].z = i;
            DrawLine(points);
        }
        points[0].z = 10;
        points[1].z = 0;
        
        for (int i = 0; i < 10; i++)
        {
            points[0].x = points[1].x = i;
            DrawLine(points);
        }
        points[0].y = 0;
        points[1].y = 10;
        points[0].z = points[1].z = 0;
        
        lineRenderer.startWidth = lineRenderer.endWidth = 0.01f;
        for (int i = 0; i < 10; i++)
        {
            points[0].x = points[1].x = i;
            DrawLine(points);
        }

        points[0].x = 0;
        points[1].x = 10;
        for (int i = 0; i < 10; i++)
        {
            points[0].y = points[1].y = i;
            DrawLine(points);
        }

        points[0].x = points[1].x = 0;
        points[0].z = 0;
        points[1].z = 10;
        for (int i = 0; i < 10; i++)
        {
            points[0].y = points[1].y = i;
            DrawLine(points);
        }

        points[0].y = 10;
        points[1].y = 0;
        for (int i = 0; i < 10; i++)
        {
            points[0].z = points[1].z = i;
            DrawLine(points);
        }
    }
    
    private void DrawLine(Vector3[] points)
    {
        //lineRenderer.startWidth = lineRenderer.endWidth = (points[0].x == 0 || points[0].z == 0) ? 0.1f : 0.02f;
        lineRenderer.SetPositions(points);
        Instantiate(line, transform.position, transform.rotation);
    }
}