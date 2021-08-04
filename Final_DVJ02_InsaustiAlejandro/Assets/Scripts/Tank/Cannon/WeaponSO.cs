using UnityEngine;

[CreateAssetMenu(fileName = "WeaponSO", menuName = "Weapon SO")]
public class WeaponSO : ScriptableObject
{
    public BulletSO bullet;
    public Mesh model;
    [Tooltip("in unity units")] public float range;
    public int maxAmmo;
    [Tooltip("in seconds")] public float shootCooldown;
}