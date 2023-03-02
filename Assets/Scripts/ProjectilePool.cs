using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ProjectilePool : MonoBehaviour
{
    public static ProjectilePool Instance { get; private set; }
    private ObjectPool<Projectile> _pool;

    [SerializeField] private Projectile projectile;
    private int _count = 0;

    private void Start()
    {
        Instance = this;
        _pool = new(InstantiateProjectile, TakeProjectileFromPool, ReturnProjectileToPool);
    }

    private Projectile InstantiateProjectile()
    {
        Projectile newProjectile = Instantiate(projectile);
        _count++;
        newProjectile.name= projectile.name + " #" + _count;
        
        return newProjectile;
    }

    private void TakeProjectileFromPool(Projectile projectile)
    {
        projectile.gameObject.SetActive(true);
        projectile.gameObject.transform.parent = null;
    }

    private void ReturnProjectileToPool(Projectile projectile)
    {
        projectile.gameObject.SetActive(false);
        projectile.gameObject.transform.parent = transform;
    }

    public Projectile GetProjectile()
    {
        return _pool.Get();
    }

    public void ReturnProjectile(Projectile projectile)
    {
        _pool.Release(projectile);
    }

}
