using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float destroyTime = 3f;

    private void Start()
    {
        Invoke("DestroyBullet", destroyTime);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {Destroy(other.gameObject);}
        Destroy(gameObject);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
