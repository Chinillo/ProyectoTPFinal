using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisilTeledirigido : MonoBehaviour
{
    Transform target;
    Vector3 direction;
    float speed = 100;
    float rotationSpeed = 15;

    void Start()
    {
        target = GameObject.Find("UFO").transform;
    }
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); //movimiento del misil

        if (target != null)
        {
            direction = target.position - transform.position;
            direction = direction.normalized;
            var rot = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, rot, rotationSpeed * Time.deltaTime);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ufo"))
        {
            Destroy(this.gameObject);
        }
    }
}
