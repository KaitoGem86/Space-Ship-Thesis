using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] public BulletSpawner bulletSpawner;

    private GameObject bulletPrefab;

    private float maxHp = 10;
    private float hp = 10;
    private float speed = 4;

    public float Hp
    {
        get { return hp; }
        set { hp = value; }
    }


    protected virtual void Move()
    {
        Vector2 direction = InputController.Instance.GetInputMove();
        direction.Normalize();
        rb.velocity = direction * speed;
    }

    protected virtual void Attack()
    {
        if (InputController.Instance.GetInputAttack())
        {
            var bullet = bulletSpawner.GetBullet();
            bullet.gameObject.SetActive(true);
        }
    }

    protected virtual void Damage(float dame)
    {
        hp -= dame;
    }
}
