using System;

[Serializable]
public class WeaponData
{
    public WeaponSO so;
    public int currentAmmo;
    public bool readyToShoot;

    public void SetCurrents()
    {
        currentAmmo = so.maxAmmo;
        readyToShoot = true;
    }
}