using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickableItem : MonoBehaviour, IInteractable
{
    public void Use()
    {
        Debug.Log("Pick up " + gameObject.name);
    }
}
