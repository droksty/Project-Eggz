using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishSection : MonoBehaviour
{
    private GameManager gameManager;


    // Functions //

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            gameManager.EndLevel();
        }
    }
}
