using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] private LayerMask obstacleLayer;
    [SerializeField] Transform eyes;
    [SerializeField] Transform player;
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private Transform[] patrolPoints;
    [SerializeField] private float detectionRange = 5;
    int patrolPointIndex = 0;
    public bool playerDetected;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        DetectPlayer();
        if (!playerDetected)
        {
            MoveToPatrolPoint();
        }
        else
        {
            MoveToPlayer();
        }
    }

    void MoveToPlayer()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;
        transform.Translate(moveSpeed * Time.deltaTime * directionToPlayer);

    }

    void DetectPlayer()
    {
        playerDetected = false;
        float distanceToPlayer = Vector3.Distance(player.position, transform.position);
        bool playerInRange = distanceToPlayer < detectionRange;
        if (playerInRange)
        {
            Color rayColor = Color.white;
            Vector3 directionToPlayer = (player.position - transform.position).normalized;
            if (!Physics.Raycast(eyes.position, directionToPlayer, out RaycastHit hit, distanceToPlayer, obstacleLayer))
            {
                rayColor = Color.red;
                playerDetected = true;
            }
        }
    }

    [SerializeField] private float rotationSpeed = 10;

    void MoveToPatrolPoint()
    {

        Transform currentPatrolPoint = patrolPoints[patrolPointIndex];
        Vector3 directionToPoint = (currentPatrolPoint.position - transform.position).normalized;
        transform.Translate(moveSpeed * Time.deltaTime * directionToPoint,Space.World);
        Quaternion toTarget = Quaternion.LookRotation(directionToPoint);
        //transform.rotation = Quaternion.Slerp(transform.rotation, toTarget, rotationSpeed * Time.deltaTime);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toTarget, rotationSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, currentPatrolPoint.position) < 0.1f)
        {
            //patrolPointIndex = Random.Range(0, patrolPoints.Length); // Losowy punkt

            // Nastêpny punkt
            Debug.Log("Next point");
            patrolPointIndex++;
            if (patrolPointIndex >= patrolPoints.Length)
            {
                patrolPointIndex = 0;
            }
            //patrolPointIndex = (patrolPointIndex + 1) % patrolPoints.Length; // To samo co wy¿ej, ale ³adniej
        }
    }
    [SerializeField] private float detectionAngle = 45;

    [SerializeField] Vector3 point1;
    [SerializeField] Vector3 point2;
    [SerializeField] float t;

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawLine(point1,point2);
        Gizmos.DrawSphere(Vector3.Lerp(point1, point2, t), 0.1f);
        float leftAngle = eyes.rotation.eulerAngles.y + detectionAngle;
        Vector3 leftDirection =   Quaternion.Euler(new Vector3(0, detectionAngle, 0)) * eyes.forward;
        Gizmos.DrawRay(eyes.position, leftDirection*3);
        Vector3 rightDirection = Quaternion.Euler(new Vector3(0, -detectionAngle, 0)) * eyes.forward;
        Gizmos.DrawRay(eyes.position, rightDirection * 3);
        DrawEyesDetectionLine();
        DrawPatrolPoints();


    }

    void DrawEyesDetectionLine()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
        Gizmos.color = Color.blue;
        Vector3 directionToPlayer = (player.position - transform.position).normalized;

        float distanceToPlayer = Vector3.Distance(player.position, transform.position);
        if (Physics.Raycast(eyes.position, directionToPlayer, out RaycastHit hit, distanceToPlayer, obstacleLayer))
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(hit.point, 0.2f);

        }
        Gizmos.DrawRay(eyes.position, directionToPlayer * distanceToPlayer);
    }

    void DrawPatrolPoints()
    {
        for (int i = 0; i < patrolPoints.Length; i++)
        {
            // Set sphere color
            if (patrolPointIndex == i)
            {
                Gizmos.color = Color.green;
            }
            else
            {
                Gizmos.color = Color.yellow;
            }

            Gizmos.DrawSphere(patrolPoints[i].position, 0.2f);

            // Set line color
            Debug.Log($"Patrol point index {patrolPointIndex} i {i}");
            if (patrolPointIndex == i + 1 || patrolPointIndex == 0 && i == patrolPoints.Length - 1)
            {
                Gizmos.color = Color.green;
            }
            else
            {
                Gizmos.color = Color.yellow;
            }

            if (i < patrolPoints.Length - 1)
            {
                Gizmos.DrawLine(patrolPoints[i].position, patrolPoints[i + 1].position);
            }
            else
            {
                Gizmos.DrawLine(patrolPoints[i].position, patrolPoints[0].position);

            }
        }
    }
}
