using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGenartaion : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject[] levelFragments;
    //private List<GameObject> spawnedLevelFramgents = new List<GameObject>();

    void Start()
    {
        SpawnRandomLevelFragment();

    }

    // Update is called once per frame
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SpawnRandomLevelFragment();
        }
    }

    public void SpawnRandomLevelFragment()
    {
        int randomLevelIndex = Random.Range(0, levelFragments.Length);
        GameObject objectToSpawn = levelFragments[randomLevelIndex];
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPoint.position,spawnPoint.rotation);
        Destroy(spawnedObject, 20);
    }
}
