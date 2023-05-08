using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Weapon weapon;

    private GameObject bulletPrefab;
    private float speed = 3;

    private void Start()
    {
        bulletPrefab = weapon.bulletPrefab;
    }

    protected virtual void Move()
    {
        Vector2 direction = InputController.Instance.GetInputMove();
        rb.velocity = direction * speed;
    }

    protected virtual void Attack()
    {   
        bulletPrefab = weapon.SetBullet();
        if (InputController.Instance.GetInputAttack())
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }
}
