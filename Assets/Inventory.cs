using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Hashset to kolekcja w której nie ma duplikatów
    private List<string> itemNames = new List<string>();
    private Item selectedItem;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            // Zrób coœ z ka¿dym elementem listy
            foreach (string itemName in itemNames)
            {
                // itemName to nazwa ka¿dego kolejnego elementu w liœcie/tablicy
                //Debug.Log(itemName);
            }

            for(int i = 0; i < itemNames.Count; i++)
            {
                Debug.Log(itemNames[i]);
            }
        }

        if (Input.GetKey(KeyCode.Tab))
        {
            SelectClosestItem();
        }
        else if (selectedItem != null)
        {
            selectedItem.SetNormalColor();
        }
    }

    private void SelectClosestItem()
    {
        // ZnajdŸ wszystkie obiekty na scenie ze <Skryptem>
        Item[] items = FindObjectsByType<Item>(FindObjectsSortMode.None);
        Item closestItem = null;
        float bestDistance = float.MaxValue;
        foreach (Item item in items)
        {
            float distance = Vector3.Distance(transform.position, item.transform.position);
            if (distance < bestDistance)
            {
                bestDistance = distance;
                closestItem = item;
            }
        }

        if (closestItem != null)
        {
            if (selectedItem != null)
            {
                selectedItem.SetNormalColor();
            }
            selectedItem = closestItem;
            closestItem.Highlight();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Item item))
        {
            //bool hasItem = false;
            //foreach (string itemName in itemNames)
            //{
            //    if(itemName == item.gameObject.name)
            //    {
            //        hasItem = true;
            //        break; // Przerywa pêtle
            //    }
            //}

            //if(!hasItem)
            //if(!itemNames.Contains(item.gameObject.name))
            {
                itemNames.Add(item.gameObject.name);
            }

        }
    }
}
