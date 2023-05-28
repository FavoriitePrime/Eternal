using UnityEngine;

[CreateAssetMenu(fileName = "Gun", menuName = "Weapon/Gun")]
public class WeaponData : ScriptableObject
{
    public float damage;
    public float fireRate;
    public float reloadTime;
    public int chamberSize;
    public Mesh mesh;
    public GameObject projectilePrefab;
}
