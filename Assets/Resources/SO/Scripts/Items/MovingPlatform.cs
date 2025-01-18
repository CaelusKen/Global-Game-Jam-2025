using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] List<Transform> points;
    private int currentPoint = 0;
    private void Awake()
    {
      
    }
    private void OnMouseDown()
    {
        this.transform.position = points[currentPoint].position;
        currentPoint++;
        if (currentPoint >= points.Count)
        {
            currentPoint = 0;
        }
    }
}
