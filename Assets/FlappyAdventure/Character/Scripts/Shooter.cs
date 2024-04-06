using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private Transform _bulletStartPoint;
    [SerializeField] private Bullet _bulletPrefab;
    [SerializeField] private float _bulletLifeTime;
    [SerializeField] private float _startSpeed;
    [SerializeField] private int _bulletDamage;

    public void Shoot(int directionX)
    {
        Bullet bullet = Instantiate(_bulletPrefab);
        bullet.transform.SetPositionAndRotation(_bulletStartPoint.position, transform.rotation);
        bullet.Initialize(_startSpeed * directionX, _bulletDamage, _enemyLayer, _bulletLifeTime);
    }

    public IEnumerator Shooting(float delay, int directionX)
    {
        var wait = new WaitForSeconds(delay);

        while (enabled)
        {
            Bullet bullet = Instantiate(_bulletPrefab);
            bullet.transform.SetPositionAndRotation(_bulletStartPoint.position, transform.rotation);
            bullet.Initialize(_startSpeed * directionX, _bulletDamage, _enemyLayer, _bulletLifeTime);

            yield return wait;
        }
    }
}
