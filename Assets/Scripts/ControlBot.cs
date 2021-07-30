using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlBot : MonoBehaviour
{
    public int contadorBots;
    private int hp;
    public OffscreenIndicators Indicators;
    void Start()
    {
        hp = 100;
    }

    public void recibirDaño()
    {
        hp = hp - 50;

        if (hp <= 0)
        {
            Desaparecer();
        }

       if(contadorBots <= 0)
        {
            ControlHud.victory = true;
        }
    }

    private void Desaparecer()
    {
        Destroy(gameObject);
        contadorBots = contadorBots - 1;
    }


    public void GameOver()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            recibirDaño();
        }

        if (collision.gameObject.CompareTag("Misil"))
        {
            recibirDaño();
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
