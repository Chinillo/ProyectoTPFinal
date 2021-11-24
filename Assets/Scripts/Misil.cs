using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Misil : MonoBehaviour
{
    public GameObject enemigo;
    [SerializeField] float rotationSpeed;
    [SerializeField] float speed;
    [SerializeField] float failRadius;
    [SerializeField] GameObject explosionMisil;
    


    private void Update()
    {
        if (enemigo != null)
        {
            GoToTarget();
        }
        else
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }

    void GoToTarget()
    {
        Quaternion desireRotation = Quaternion.LookRotation(enemigo.transform.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, desireRotation, rotationSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
