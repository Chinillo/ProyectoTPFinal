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
    public int cantidadBots;

    //public GameObject botUno;
    //public GameObject botDos;

    public static int contadorBotsDestruidos;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Reset()
    {
        this.transform.position = startPos;
    }

   //public void mateUnBot()
   // {
   //     contadorBotsDestruidos++;
   // }
    void Update()
    {
        
        if (contadorBotsDestruidos >= cantidadBots)
        {
           ControlHud.victory = true;
        }

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
            Time.timeScale = 0;
            ControlHud.gameOver = true;
            AudioSource[] audios = FindObjectsOfType<AudioSource>();
            foreach (AudioSource a in audios)
            {
                a.Pause();
            }
        }

        if(collision.gameObject.CompareTag("Suelo"))
        {
            Time.timeScale = 0;
            ControlHud.gameOver = true;
        }
    }
    
}
