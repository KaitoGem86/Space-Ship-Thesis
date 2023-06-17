using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemControll : MonoBehaviour
{
    [SerializeField] private DropItemList list;

    private Vector2 instantiatePos;

    public Vector2 InstantiatePos
    {
        get { return instantiatePos; }
        set { instantiatePos = value; }
    }

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    DropItem GetItem()
    {
        int ran = Random.Range(0, 100);
        if (ran < 50)
            return list.Items[0];
        else
            return list.Items[1];
    }

    public void InstantiateItem()
    {
        Debug.Log("Drop");
        DropItem item = GetItem();
        int i = Random.Range(0, 100);
        if (i < 40)
            Instantiate(item.gameObject, instantiatePos, Quaternion.identity);
    }
}
