using Custom.Indicators;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlBot : MonoBehaviour
{
    //public int cantidadBots;
    //public int contadorBotsDestruidos;
    private int hp;
    public ParticleSystem explosion;
    
    void Start()
    {
        hp = 100;
    }

    void Update()
    {
        //if (contadorBotsDestruidos >= cantidadBots)
        //{
        //    ControlHud.victory = true;
        //}

        //if (cantidadBots <= 0)
        //{
        //    ControlHud.victory = true;
        //}
    }

    public void recibirDaño()
    {
        hp = hp - 50;

        if (hp <= 0)
        {
            Desaparecer();
        }

       //if(cantidadBots <= 0)
       // {
       //    ControlHud.victory = true;
       // }
    }

    public void Desaparecer()
    {
        explosion.Play();
        Destroy(gameObject);
        ControlAvion.contadorBotsDestruidos++;
    }

    


    public void GameOver()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bala"))
        {
            Desaparecer();
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
