using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionSystem : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Input.GetMouseButtonDown(0) && Physics.Raycast(ray, out RaycastHit hitInfo))
        {
            if(hitInfo.collider.TryGetComponent(out IInteractable interactable))
            {
                interactable.Use();
            }
        }
    }
}
