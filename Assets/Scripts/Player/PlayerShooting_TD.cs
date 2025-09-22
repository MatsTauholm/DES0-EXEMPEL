using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField] float bulletForce = 0;

    public Transform firePoint;
    public GameObject playerBullet;
  
    void OnFire()
    {
        GameObject bullet = Instantiate(playerBullet, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletForce, ForceMode2D.Impulse);
    }
}
