using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class EnemyPool : MonoBehaviour
{
    public static EnemyPool Instance { get; private set; }
    private ObjectPool<Enemy> _pool;

    [SerializeField] private Enemy enemy;
    private int _count = 0;

    private void Start()
    {
        Instance = this;
        _pool = new(InstantiateEnemy, TakeEnemyFromPool, ReturnEnemyToPool);
    }

    private Enemy InstantiateEnemy()
    {
        Enemy newEnemy = Instantiate(enemy);
        _count++;
        newEnemy.name= enemy.name + " #" + _count;
        
        return newEnemy;
    }

    private void TakeEnemyFromPool(Enemy enemy)
    {
        enemy.gameObject.SetActive(true);
        enemy.gameObject.transform.parent = null;
    }

    private void ReturnEnemyToPool(Enemy enemy)
    {
        enemy.gameObject.SetActive(false);
        enemy.gameObject.transform.parent = transform;
    }

    public Enemy GetEnemy()
    {
        return _pool.Get();
    }

    public void ReturnEnemy(Enemy enemy)
    {
        _pool.Release(enemy);
    }

}
