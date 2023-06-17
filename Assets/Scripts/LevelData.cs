using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class IndexData
{
    [SerializeField] public List<int> listIndex;
}


[CreateAssetMenu(menuName = "Level Data")]
public class LevelData : ScriptableObject
{
    [SerializeField] public List<IndexData> data;
}
