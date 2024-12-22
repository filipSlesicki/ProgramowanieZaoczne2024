using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    public Player player;

    // To siê wykonuje jak wejdê w collider ustawiony jako trigger
    private void OnTriggerEnter(Collider other)
    {
        player.canJump = true;
    }

    //To sie wykonuje jak wejd¹ w siebie 2 collidery, z których ¿aden nie jest triggerem
    private void OnCollisionEnter(Collision collision)
    {
    }

    private void OnDisable()
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        player.canJump = false;
    }
}
