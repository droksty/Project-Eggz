using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySection : MonoBehaviour
{
    private LevelGenerator levelGenerator;


    // Functions //

    void Awake()
    {
        levelGenerator = FindObjectOfType<LevelGenerator>();
    }


    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject, 1); /* Replace with object pooling code */

            if (Eggstravaganza.isEndless == true)
            {
                levelGenerator.GenerateSection();
            }
            
            /* Future update to add logic to spawn more sections if not endless,
             * based on some kind of counter, in order to increase normal level length. */
        }
    }
}
