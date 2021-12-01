using Custom.Indicators;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;
using UnityEngine.UI;

public class ControlBot : MonoBehaviour
{
    
    private int hp;
    //public ParticleSystem explosion;
    public VisualEffect chispitas;
    
    void Start()
    {
        //chispitas.Stop();
        hp = 100;
    }

    void Update()
    {
        
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
        //explosion.Play();
        SpawnParticle();
        Destroy(gameObject);
        ControlAvion.contadorBotsDestruidos++;
    }


    private void SpawnParticle()
    {
        VisualEffect newChispitasEffect = Instantiate(chispitas, transform.position, transform.rotation);
        newChispitasEffect.Play();
        Destroy(newChispitasEffect.gameObject, 3f);
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
            Desaparecer();
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
