using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] BulletData[] bulletDatas;
    public GameObject bulletPrefab;
    private int indexBullet = 0;

    private void Start()
    {
        bulletPrefab = bulletDatas[indexBullet].bulletPrefab;
    }

    public GameObject SetBullet()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
            indexBullet = (indexBullet + 1) % bulletDatas.Length;
        bulletPrefab = bulletDatas[indexBullet].bulletPrefab;
        return bulletPrefab;
    }
}
