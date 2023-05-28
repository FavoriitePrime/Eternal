using System.Collections;

public interface IWeapon
{
    public void StartReload();
    public void Shoot();
    public abstract IEnumerator Reload();
}