using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    private float elapsedTime;

    [SerializeField] private TextMeshProUGUI elapsedTimeUI;


    // Functions //

    void Start()
    {
        elapsedTimeUI.gameObject.SetActive(true);
    }


    void Update()
    {
        elapsedTime = elapsedTime += Time.deltaTime;
        elapsedTimeUI.text = "Elapsed Time: " + elapsedTime.ToString("0");
    }


    public void StopTimer()
    {
        if (Eggstravaganza.highScore < elapsedTime)
        {
            Eggstravaganza.highScore = elapsedTime;
        }

        gameObject.SetActive(false);
    }
}
