using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private Transform[] patrolPoints;
    int patrolPointIndex = 0;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Transform currentPatrolPoint = patrolPoints[patrolPointIndex];
        Vector3 directionToPoint = (currentPatrolPoint.position - transform.position).normalized;
        transform.Translate(moveSpeed * Time.deltaTime * directionToPoint);

        if(Vector3.Distance(transform.position, currentPatrolPoint.position) < 0.1f)
        {
            //patrolPointIndex = Random.Range(0, patrolPoints.Length); // Losowy punkt

            // Nastêpny punkt
            patrolPointIndex++;
            if (patrolPointIndex >= patrolPoints.Length)
            {
                patrolPointIndex = 0;
            }
            //patrolPointIndex = (patrolPointIndex + 1) % patrolPoints.Length; // To samo co wy¿ej, ale ³adniej
        }
    }
}
