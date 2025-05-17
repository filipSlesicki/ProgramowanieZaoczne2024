using System.Collections;
using System.Collections.Generic;
using System.Data;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR;

public class Turret : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] float rotationSpeed = 30;
    [SerializeField] Weapon weapon;
    [SerializeField] float detectionRange= 10;
    [SerializeField] float detectionAngle = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 toTarget = player.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(toTarget);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        //
        float sqareDistance = toTarget.sqrMagnitude;
        float angle = Vector3.Angle(transform.forward, toTarget);
        if(sqareDistance < detectionRange * detectionRange && angle < detectionAngle/2)
        {
            weapon.Shoot();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 dirLeft = Quaternion.Euler(0, -detectionAngle/2, 0) * transform.forward;
        Vector3 dirRight = Quaternion.Euler(0, detectionAngle/2, 0) * transform.forward;
        Gizmos.DrawRay(transform.position, dirLeft * detectionRange);
        Gizmos.DrawRay(transform.position, dirRight * detectionRange);
        Vector3 from = Quaternion.Euler(0f, -detectionAngle / 2f, 0f) * transform.forward;

        Handles.DrawWireArc(transform.position, transform.up,from, detectionAngle, detectionRange);
    }
}
