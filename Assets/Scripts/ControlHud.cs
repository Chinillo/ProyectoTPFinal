using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlHud : MonoBehaviour
{
    public static bool pullUp = false;
    public static bool gameOver = false;
    public static bool victory = false;
    public Text victoryText;
    public Text gameOverText;
    public Text distanceText;
    public Text speedText;
    public Text alturaText;
    public Text pullupText;
    public float altura;
    public float speed = 40;
    public float distance;
    public GameObject avion;

    void Start()
    {
        pullUp = false;
        victory = false;
        gameOver = false;
        //altura = avion.transform.position.y;
        speed = 40;
        distance = 0;
        alturaText.text = " " + altura;
        speedText.text = " " + speed;
        distanceText.text = "Distancia " + distance.ToString();
        pullupText.gameObject.SetActive(false);
        distanceText.gameObject.SetActive(true);
        victoryText.gameObject.SetActive(false);
        gameOverText.gameObject.SetActive(false);
    }

    void Update()
    {
        altura = avion.transform.position.y;
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

        if (altura < 080)
        {
            pullupText.gameObject.SetActive(true);
        }
        else
        {
            pullupText.gameObject.SetActive(false);
        }

        //if (pullUp)
        //{
        //    pullupText.text = "¡PULL UP!";
        //    pullupText.gameObject.SetActive(true);
        //}

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
