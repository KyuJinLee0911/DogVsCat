using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu ( fileName = "CatData", menuName = "Scriptable Object Asset / CatData")]
public class CatData : ScriptableObject
{
    public CatType catType;
    public float full;
    public float speed;
    public float energy;
}
