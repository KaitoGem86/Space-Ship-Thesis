using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoriteData: MonoBehaviour
{
    [SerializeField] private MeteoriteController[] data;

    public MeteoriteController[] Data
    {
        get { return data; }
    }
}
