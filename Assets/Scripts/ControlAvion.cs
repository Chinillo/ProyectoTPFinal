using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlAvion : MonoBehaviour
{
    public float speed = 20;
    public float maxSpeed = 100;
    public float minSpeed = 5;
    public float rootSpeed1 = 50;
    public float rootSpeed2 = 50;
    public static ControlAvion _Player;
    private Vector3 startPos;
    public Camera camaraEnPrimeraPersona;
    public float misilForce = 20f;
    public Transform firePoint;
    public GameObject misilPrefab;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Reset()
    {
        this.transform.position = startPos;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rootSpeed1 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * rootSpeed2 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            transform.Rotate(Vector3.left * rootSpeed1 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            transform.Rotate(Vector3.right * rootSpeed1 * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            if (speed <= maxSpeed)
            {
                speed += 2;
            }
        }

        if(Input.GetKeyDown(KeyCode.E))
        {
            if (speed >= minSpeed)
            {
                speed--;
            }
        }

        transform.position += transform.forward * speed * Time.deltaTime;

        if (Input.GetKeyDown("escape"))
        {
            Cursor.lockState = CursorLockMode.None;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            Shoot();
        }
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(misilPrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * misilForce, ForceMode.Impulse);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ufo"))
        {
            Destroy(this.gameObject);
            ControlHud.gameOver = true;
        }

        if(collision.gameObject.CompareTag("Suelo"))
        {
            Destroy(this.gameObject);
            ControlHud.gameOver = true;
        }
    }
}
