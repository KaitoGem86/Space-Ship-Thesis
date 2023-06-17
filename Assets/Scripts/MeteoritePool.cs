using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeteoritePool : MonoBehaviour
{
    [SerializeField] private MeteoriteData data;

    private int poolSize = 100;

    private MeteoriteController[] meteorites;

    private System.Random random = new System.Random();
    private float range = 120;


    private Vector2 orbit = new Vector2(90, 130);
    private void Start()
    {
        SetMeteoritePool();
    }

    private void Update()
    {
    }

    void SetMeteoritePool()
    {
        meteorites = new MeteoriteController[poolSize];
        for(int i = 0; i < poolSize; i++)
        {
            MeteoriteController mt = GetMeteorite();

            Vector2 pos = new Vector2();

            pos.x = orbit.x - (i % 25) * 4 + Random.Range(-1,1);
            pos.y = orbit.y - Mathf.Sqrt((range + (i % 4)*4) * (range + (i % 4) * 4) - (pos.x - 100) * (pos.x-100));

            var t = Instantiate(mt.gameObject, pos, Quaternion.identity, this.transform );
        }
    }

    MeteoriteController GetMeteorite()
    {
        MeteoriteController mt = new MeteoriteController();
        int index = 0;
        index = random.Next(0, data.Data.Length);
        mt = data.Data[index];
        return mt;
    }

}
