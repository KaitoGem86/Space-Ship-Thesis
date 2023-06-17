using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
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
    private float timeAttack = 0.1f;
    private float exp = 0;
    private float expLimitation = 20;
    private float stamina = 3;
    private float baseStamina = 3;

    public float Hp
    {
        get { return hp; }
        set { hp = value; }
    }


    public float MaxHP
    {
        get { return maxHp; }
    }

    public float Exp
    {
        get { return exp; }
        set { exp = value; }
    }

    public float ExpLimitation
    {
        get { return expLimitation; }
    }

    public Rigidbody2D Rb
    {
        get { return rb; }
        set { rb = value; }
    }

    public BulletSpawner BulletSpawner
    {
        get { return this.bulletSpawner; }
    }

    protected virtual void Move()
    {
        Vector2 direction = InputController.Instance.GetInputMove();
        if (this.transform.position.x + direction.normalized.x / 10 < -10f || this.transform.position.x + direction.normalized.x / 10 > 70.3f)
        {
            direction.x = 0;
        }
        if (this.transform.position.y + direction.normalized.y / 10 < -14.3f || this.transform.position.y + direction.normalized.y / 10 > 65f)
        {
            direction.y = 0;
        }
        if (GameManager.instance.isWin)
        {
            direction = this.transform.up;
        }
        direction.Normalize();
        rb.velocity = direction * speed;
    }

    protected virtual void Attack()
    {
        if (timeAttack <= 0)
        {
            var bullet = bulletSpawner.GetBullet();
            bullet.SetPosition();
            bullet.gameObject.SetActive(true);
            timeAttack = 0.1f;
        }
        else
        {
            timeAttack -= Time.deltaTime;
        }

    }

    protected virtual void Damage(float dame)
    {
        hp -= dame;
    }

    protected virtual void SpeedUp()
    {
        if (InputController.Instance.GetInputSpeedUp() && stamina > 0)
        {
            speed += 5;
        }
        if (speed > baseSpeed)
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
        if (stamina < baseStamina)
            stamina += Time.deltaTime * 0.5f;
    }

    public void UpdateLevel(int level)
    {
        this.speed += level * 0.5f;
        this.stamina += level * 0.3f;
        this.maxHp += level * 5;
        this.Hp = this.maxHp;
    }

    public void PlayerWinGame()
    {
        if (this.transform.position.y > 8)
        {
            Time.timeScale = 1;
            this.gameObject.SetActive(false);
            UIManager.instance.WinGame();
            Debug.Log("WinGame");
        }
    }
}
