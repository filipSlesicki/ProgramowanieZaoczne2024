using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Hashset to kolekcja w kt�rej nie ma duplikat�w
    private HashSet<string> itemNames = new HashSet<string>();

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            // Zr�b co� z ka�dym elementem listy
            foreach (string itemName in itemNames)
            {
                // itemName to nazwa ka�dego kolejnego elementu w li�cie/tablicy
                Debug.Log(itemName);
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Znajd� wszystkie obiekty na scenie ze <Skryptem>
            Item[] items = FindObjectsByType<Item>(FindObjectsSortMode.None);
            foreach (Item item in items)
            {
                item.Highlight();
            }
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            Item[] items = FindObjectsByType<Item>(FindObjectsSortMode.None);
           
            foreach (Item item in items)
            {
                item.SetNormalColor();
            }
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
            //        break; // Przerywa p�tle
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
