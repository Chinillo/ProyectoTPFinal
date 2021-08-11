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
    public Text speedText;
    public Text alturaText;
    public float altura;
    public float speed = 40;
    public float distance;
    public GameObject avion;

    void Start()
    {
        victory = false;
        gameOver = false;
        speed = 40;
        distance = 0;
        alturaText.text = " " + altura;
        speedText.text = " " + speed;
        distanceText.text = "Distancia " + distance.ToString();
        distanceText.gameObject.SetActive(true);
        victoryText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
    }

    void Update()
    {
        alturaText.text = avion.transform.position.y.ToString("000");
        speedText.text = " " + speed;
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

        if (Input.GetKeyDown(KeyCode.Q))
        {
            speed += 2;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            speed -= 2;
        }

    }
}
