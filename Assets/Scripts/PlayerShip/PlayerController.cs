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
    private float baseSpeed = 4;
    private float stamina = 3;
    private float baseStamina = 3;

    public float Hp
    {
        get { return hp; }
        set { hp = value; }
    }


    protected virtual void Move()
    {
        Vector2 direction = InputController.Instance.GetInputMove();
        if(this.transform.position.x + direction.normalized.x / 10 < -10f || this.transform.position.x + direction.normalized.x / 10 > 70.3f)
        {
            direction.x = 0;
        }
        if(this.transform.position.y + direction.normalized.y / 10 < -14.3f || this.transform.position.y + direction.normalized.y / 10 > 65f)
        {
            direction.y = 0;
        }
        direction.Normalize();
        rb.velocity = direction * speed;
    }

    protected virtual void Attack()
    {
        if (InputController.Instance.GetInputAttack())
        {
            var bullet = bulletSpawner.GetBullet();
            bullet.SetPosition();
            bullet.gameObject.SetActive(true);
        }
    }

    protected virtual void Damage(float dame)
    {
        hp -= dame;
    }

    protected virtual void SpeedUp()
    {
        if(InputController.Instance.GetInputSpeedUp() && stamina > 0)
        {
            speed += 5;
        }
        if(speed > baseSpeed)
        {
            stamina -= Time.deltaTime;
        }
        if (stamina < 0)
        {
            speed -= 5;
        }
        RechargeStamina();
    }

    protected void RechargeStamina()
    {   
        if(stamina < baseStamina )
            stamina += Time.deltaTime * 0.5f;
    }
}
