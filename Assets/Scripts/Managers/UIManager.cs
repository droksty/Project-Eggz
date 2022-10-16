using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private GameObject levelFinishedPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject navButtons;

    [SerializeField] private TextMeshProUGUI eggsLeftText;
    [SerializeField] private TextMeshProUGUI endResultText;


    // Functions //

    public void UpdateEggsLeftText(int eggs)
    {
        eggsLeftText.text = "Eggs Left: " + Mathf.Clamp(eggs, 0, Mathf.Infinity).ToString();
    }


    public void ActivatePausePanel(bool Bool)
    {
        pauseMenuPanel.SetActive(Bool);
        navButtons.SetActive(Bool);
    }


    public void ActivateGameOverPanel(bool Bool)
    {
        gameOverPanel.SetActive(true);
        navButtons.SetActive(Bool);
    }


    public void ActivateLevelFinishPanel(string result, bool Bool)
    {
        endResultText.text = result;
        levelFinishedPanel.SetActive(true);
        navButtons.SetActive(Bool);
    }
}
