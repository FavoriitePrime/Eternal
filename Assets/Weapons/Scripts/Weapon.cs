using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour, IWeapon
{
    [SerializeField] private WeaponData weaponData;
    [SerializeField] private Vector3 _firePointOffset;
    private int _bulletsInChamber;
    private bool _isReloading;

    private void Start()
    {
        _bulletsInChamber = weaponData.chamberSize;
    }

    public void StartReload()
    {
        if(_isReloading) return;
        StartCoroutine(Reload());
    }

    public void Shoot()
    {
        if (_isReloading) return;
        if (_bulletsInChamber <= 0) StartReload();
        _bulletsInChamber--;
        Instantiate(weaponData.projectilePrefab, transform.position + transform.TransformDirection(_firePointOffset), transform.rotation);
    }
    public IEnumerator Reload()
    {
        _isReloading = true;
        yield return new WaitForSeconds(weaponData.reloadTime);
        _bulletsInChamber = weaponData.chamberSize;
        _isReloading = false;
    }
#if UNITY_EDITOR
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position + transform.TransformDirection(_firePointOffset), 0.1f);
    }
#endif
}
