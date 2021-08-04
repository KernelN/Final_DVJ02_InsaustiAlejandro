using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public WeaponData data;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] Transform bulletEmpty;
    [SerializeField] GameObject shootEffect;
    [SerializeField] Transform effectEmpty;
    MeshFilter meshFilter;

    private void Start()
    {
        meshFilter = GetComponent<MeshFilter>();
        UpdateModel();
        data.SetCurrents();
    }

    #region Methods
    public void UpdateModel()
    {
        if (data.so.model != null)
        {
            meshFilter.mesh = data.so.model;
        }
    }
    public void Shoot(Vector3 shootDirection)
    {
        if (!data.readyToShoot) { return; }

        BulletSO bullet = data.so.bullet;
        if (bullet != null)
        {
            Transform bulletTransform = Instantiate(bulletPrefab, bulletEmpty).transform;
            bulletTransform.GetComponent<BulletController>().data = bullet;
            bulletTransform.position = transform.position;
            bulletTransform.rotation = Quaternion.LookRotation(shootDirection);
        }
        else
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, shootDirection, out hit))
            {
                hit.transform.GetComponent<IHittable>()?.GetHitted();
                Transform effect = Instantiate(shootEffect, effectEmpty).transform;
                effect.up = hit.normal;
                effect.position = hit.point;
            }            
        }
        data.currentAmmo--;
        data.readyToShoot = false;
        Invoke("SetShootReady", data.so.shootCooldown);
    }
    public void SetShootReady()
    {
        data.readyToShoot = data.currentAmmo > 0 || data.so.maxAmmo == 0;
    }
    public void Recharge(int rechargeAmount)
    {
        data.currentAmmo += rechargeAmount;
        if (data.currentAmmo > data.so.maxAmmo)
        {
            data.SetCurrents(); //ammo = max ammo
        }
    }
    #endregion
}