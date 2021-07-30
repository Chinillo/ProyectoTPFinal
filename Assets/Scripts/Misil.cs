using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misil : MonoBehaviour
{
    [SerializeField] private Transform m_target = null; //marcaje
    [SerializeField] private float m_speed = 0.0f; //velocidad de movimiento
    [SerializeField] private float m_followRate = 0.0f; //angulo de rate para pegar al enemigo
    public GameObject boom;


    private void Update()
    {
        Quaternion desireRotation = Quaternion.LookRotation(m_target.position - transform.position); //deseamos la rotacion por la cual el misil irá hacia el target
        transform.rotation = Quaternion.Slerp(transform.rotation, desireRotation, m_followRate * Time.deltaTime); //hago esto para que el misil no mire siempre al objetivo sino que lo encuentre

        transform.Translate(Vector3.forward * Time.deltaTime * m_speed); //para que el misil avance

        
    }

    public void OnCollisionEnter(Collision collision)
    {
        OnBoom();
    }

    public void OnBoom()
    {
        Instantiate(boom, transform.position, Quaternion.identity);
        Destroy(gameObject, 0.2f);
    }
}
