using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    public Player player;

    private void OnTriggerEnter(Collider other)
    {
        player.canJump = true;
    }

    private void OnTriggerExit(Collider other)
    {
        player.canJump = false;
    }
}
