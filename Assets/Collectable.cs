using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int healthToRestore = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Collceted");
            Player player = other.GetComponent<Player>();
            player.AddHealth(healthToRestore);
            Destroy(gameObject);
        }

    }
}
