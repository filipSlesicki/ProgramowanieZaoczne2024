using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    MeshRenderer meshRenderer;
    [SerializeField] Material highlightedMaterial;
    [SerializeField] Material normalMaterial;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
    }

    public void Highlight()
    {
        meshRenderer.material = highlightedMaterial;
    }

    public void SetNormalColor()
    {
        meshRenderer.material = normalMaterial;
    }
}
