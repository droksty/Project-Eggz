using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    /* Variables related to Pause mechanic */
  
    private bool isGamePaused;
    private bool isGameOver;


    /* Dependencies */

    private PlayerMovement playerMovement;
    private PlayerTrunk playerTrunk;
    private UIManager ui;
    private GameObject timer;


    // Functions //

    void Awake()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();
        playerTrunk = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTrunk>();
        ui = FindObjectOfType<UIManager>();
        timer = GameObject.Find("Managers").transform.GetChild(3).gameObject; 
    }

    
    void Start()
    {
        Cursor.visible = false;

        if (Eggstravaganza.isEndless)
        {
            timer.SetActive(true);
        }
    }
        

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGameOver) return;
            if (isGamePaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }


    public void Resume()
    {
        isGamePaused = false;
        Time.timeScale = 1f;
        Cursor.visible = false;
        ui.ActivatePausePanel(false);
    }


    public void Pause()
    {
        isGamePaused = true;
        Time.timeScale = 0f;
        Cursor.visible = true;
        ui.ActivatePausePanel(true);
    }


    public void RestartGame()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
        timer.GetComponent<Timer>().StopTimer();
    }


    public void GameOver() /* Gets called from PlayerTrunk when all eggs have been broken */
    {
        isGameOver = true;

        playerMovement.StopMovement();

        ui.ActivateGameOverPanel(true);

        timer.GetComponent<Timer>().StopTimer();
    }


    public void EndLevel() /* Gets called from FinishSection when player reaches end of level */
    {
        isGameOver = true;

        playerMovement.StopMovement();

        /* Get number of remaining eggs */
        int eggsDelivered = playerTrunk.EggsDelivered();

        /* Get end result message based on eggsDelivered */
        string endResult = SetEndResult(eggsDelivered);

        /* Pass endResult to UIManager and activate updated FinishPanel */
        ui.ActivateLevelFinishPanel(endResult, true);
    }


    private string SetEndResult(int eggs) /* Returns a text result based on eggsDelivered */
    {
        string result;

        if (eggs == 100)
        {
            result = "Impossible! You delivered all " + eggs + " eggs! You are something else!";
        } else if (eggs > 80)
        {
            result = ("Great! You delivered " + eggs + " eggs. Thank you.");
        } else if (eggs > 50)
        {
            result = ("Not bad, you delivered " + eggs + " eggs. Here's HALF payment.");
        } else if (eggs > 25)
        {
            result = ("You delivered us " + eggs + " eggs. We are keeping your payment for another courier.");
        } else 
        {
            result = ("You deliver us only " + eggs + " eggs? We are starving.. Maybe we eat you.. Wait, where are you going?");
        }

        return result;
    }
}
