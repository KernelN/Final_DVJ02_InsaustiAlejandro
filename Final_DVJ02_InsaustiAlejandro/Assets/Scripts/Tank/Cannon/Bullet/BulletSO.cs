using UnityEngine;

[CreateAssetMenu(fileName = "BulletSO", menuName = "Bullet SO")]
public class BulletSO : ScriptableObject
{
    public Mesh model;
    [Tooltip("in unity units, 0 == no explosion")] public float explosionRadius;
    [Tooltip("in unity units")] public float speed; 
    [Tooltip("this multiplied by gravity == fall speed")] public float gravityMod;
}