using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{
    public delegate void Shooting();
    public event Shooting OnShooting;
    public static Ammo ammo;
    public static int ammunition;
    public static Disparo _ShootingPlayer;
    //public GameObject misil;
    public Transform firePoint;
    public GameObject bulletPrefab;
    public GameObject misslePrefab;
    public GameObject enemigo;
    public float bulletForce = 20f;

    private void Awake()
    {
        if (_ShootingPlayer == null)
        {
            _ShootingPlayer = this.gameObject.GetComponent<Disparo>();

        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        if (_ShootingPlayer == null)
        {
            _ShootingPlayer = this.gameObject.GetComponent<Disparo>();
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            CheckAmmo();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            missleShoot();
        }
    }

    private void CheckAmmo()
    {
        if (ammunition <= 0)
        {
            ammo = Ammo.Normal;
        }
    }

    private void Shoot()
    {
        if (OnShooting != null)
        {
            OnShooting();
        }
        if (ammo == Ammo.Normal)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody rb = bullet.GetComponent<Rigidbody>();
            rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
        }
    }

    private void missleShoot()
    {
        GameObject newMissle = Instantiate(misslePrefab, firePoint.position, firePoint.rotation);
        Rigidbody rb = misslePrefab.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * bulletForce, ForceMode.Impulse);
    }

}

public enum Ammo
{
    Normal,
}