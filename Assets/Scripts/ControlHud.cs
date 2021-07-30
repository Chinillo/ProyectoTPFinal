using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlHud : MonoBehaviour
{
    public static bool gameOver = false;
    public static bool victory = false;
    public Text victoryText;
    public Text gameOverText;
    public Text distanceText;
    public float distance;

    void Start()
    {
        victory = false;
        gameOver = false;
        distance = 0;
        distanceText.text = "Distancia " + distance.ToString();
        distanceText.gameObject.SetActive(true);
        victoryText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
    }

    void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            int distanceToInt = (int)distance;
            gameOverText.text = "Game Over";
            gameOverText.gameObject.SetActive(true);
        }
        else
        {
            distance += Time.deltaTime;
            int distanceToInt = (int)distance;
            distanceText.text = distanceToInt.ToString();
        }

        if (victory)
        {
            Time.timeScale = 0;
            victoryText.text = "Victory!!!";
            victoryText.gameObject.SetActive(true);
        }


    }
}
