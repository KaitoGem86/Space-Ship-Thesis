using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemList : MonoBehaviour
{
    [SerializeField] private DropItem[] items;

    public DropItem[] Items
    {
        get { return items; }
    }
}
