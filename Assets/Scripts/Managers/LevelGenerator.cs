using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] sectionPrefab;

    [SerializeField] int sectionsToSpawn;
    [SerializeField] int zPoint; /* Instantiate first sectionPrefab at this point on z axis */
    [SerializeField] int sectionLength; /* Add to zPoint, to set next zPoint to instantiate on */


    // Functions //

    void Start()
    {
        GenerateLevel(sectionsToSpawn);
    }


    private void GenerateLevel(int length)
    {
        for (int i = 0; i < length; i++)
        {
            GenerateSection();
        }

        if (Eggstravaganza.isEndless == true) 
        {
            return;
        }

        /* Future update to add logic to generate more sections in chunks,
         * in order to get more level length. Possibly using Coroutines. */

        GenerateFinishSection();
    }


    public void GenerateSection()
    {
        int sectionNumber = Random.Range(0, 4);
        Instantiate(sectionPrefab[sectionNumber], new Vector3(0, 0, zPoint), Quaternion.identity);
        zPoint += sectionLength;
    }


    void GenerateFinishSection()
    {
        Instantiate(sectionPrefab[^1], new Vector3(0, 0, zPoint), Quaternion.identity);
    }
}
