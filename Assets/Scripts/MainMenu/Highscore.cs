using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Highscore : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI highscoreText;


    /// Functions

    void Start()
    {
        highscoreText.text = "Highscore " + Eggstravaganza.highScore.ToString("0");
    }
}
