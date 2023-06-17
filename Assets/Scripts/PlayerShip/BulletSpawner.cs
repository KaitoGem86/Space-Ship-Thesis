using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using Unity.VisualScripting;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    private GameObject bullet;
    private int poolSize = 50;
    private BulletController[] bullets;

    public Weapon Weapon { get { return weapon; } }

    private void Start()
    {
        InitPool();
    }

    private void Update()
    {
        //this.SetBullet();
    }

    private void InitPool()
    {
        bullet = weapon.SetBullet();
        if (bullets == null)
            bullets = new BulletController[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            var bulletObject = Instantiate(bullet, this.transform);
            bullets[i] = bulletObject.GetComponent<BulletController>();
            bullets[i].gameObject.SetActive(false);
        }
    }


    void ClearPool()
    {
        for (int i = poolSize - 1; i >= 0; i--)
        {
            if (bullets[i] != null) Destroy(bullets[i].gameObject);
        }
    }

    public BulletController GetBullet()
    {
        for (int i = 0; i < poolSize; i++)
        {
            if (!bullets[i].gameObject.activeSelf)
            {
                bullets[i].SetPosition();
                return bullets[i];
            }
        }
        return null;
    }

    public void SetBullet()
    {
        ClearPool();
        InitPool();
    }

}
