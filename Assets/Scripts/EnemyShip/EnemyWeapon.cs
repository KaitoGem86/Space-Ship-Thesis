using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    [SerializeField] private Enemybullet eBullet;
    [SerializeField] private BaseEnemy enemyShip;


    private GameObject eBulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        eBulletPrefab = eBullet.gameObject;
    }

    public void Attack()
    {
        var bullet = Instantiate(eBulletPrefab, this.transform.position, Quaternion.Euler(enemyShip.RotateDirection));
    }
}
