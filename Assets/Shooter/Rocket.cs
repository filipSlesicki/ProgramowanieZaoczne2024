using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] float radius;
    [SerializeField] int damage;
    [SerializeField] ParticleSystem explosion;
    private Rigidbody rigidbody;


    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        ParticleSystem explosionParticles = Instantiate(explosion, transform.position, Quaternion.identity);
        explosionParticles.startSpeed = radius;
        Destroy(explosionParticles.gameObject, 10);
        Collider[] collidersInRange = Physics.OverlapSphere(transform.position, radius);
        //Pêtla for
        //for (int i = 0; i < collidersInRange.Length; i++)
        //{
        //    Collider collider = collidersInRange[i];

        //}

        // Pêtla foreach
        foreach (Collider collider in collidersInRange)
        {
            Health health = collider.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }

        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
