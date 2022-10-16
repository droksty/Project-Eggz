using UnityEngine;

public class PlayerTrunk : MonoBehaviour
{
    private int eggsLeft; // Number of eggs Player is carrying any given moment
    private int minEggsLost; // Minimum eggs lost on collision
    private int maxEggsLost; // Maximum eggs lost on collision

    private UIManager ui;
    private GameManager gameManager;


    /// Functions ///

    void Awake()
    {
        //ui = GameObject.FindGameObjectWithTag("Managers").GetComponentInChildren<UIManager>();
        //gameManager = GameObject.FindGameObjectWithTag("Managers").GetComponentInChildren<GameManager>();

        ui = FindObjectOfType<UIManager>();
        gameManager = FindObjectOfType<GameManager>();

        SetVariables(); /* FUTURE UPDATE */
    }


    void Start()
    {
        ui.UpdateEggsLeftText(eggsLeft);
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Obstacle"))
        {
            BreakEggs(); // Break random number of eggs

            ui.UpdateEggsLeftText(eggsLeft); // Display number of remaining eggs

            if (eggsLeft <= 0)
            {
                gameManager.GameOver();
            }
        }
    }


    private void BreakEggs()
    {
        eggsLeft -= Random.Range(minEggsLost, maxEggsLost + 1);
    }


    private void SetVariables() /* Replace with code that sets values based on SCENE and/or DIFFICULTY */
    {
        eggsLeft = 100;
        minEggsLost = 1;
        maxEggsLost = 6;
    }


    public int EggsDelivered()
    {
        return eggsLeft;
    }
}
