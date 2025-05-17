using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimLine : MonoBehaviour
{
    [SerializeField] Transform startPosition;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] float maxRange = 100;
    private Vector3[] linePositions = new Vector3[2];


    private void LateUpdate()
    {
        linePositions[0] = startPosition.position;
        Ray cameraRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Debug.DrawRay(cameraRay.origin, cameraRay.direction * 20, Color.red);
        if (Physics.Raycast(cameraRay, out RaycastHit hit))
        {
            linePositions[1] = hit.point;
        }
        else
        {
            linePositions[1] = cameraRay.origin + cameraRay.direction * maxRange;
        }
        lineRenderer.SetPositions(linePositions);
    }
}
