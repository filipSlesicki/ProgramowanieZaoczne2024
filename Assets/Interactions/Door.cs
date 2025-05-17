using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public void Use()
    {
        Debug.Log("Open");
    }
}
