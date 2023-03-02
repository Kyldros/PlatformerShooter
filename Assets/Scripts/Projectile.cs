using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float destroyDelay = 5;
    [SerializeField] float speed = 1;
    private float elapsed = 0;
    Vector2 direction;

    public void InizializeProjectile(Vector3 mousePosition, Transform startingPoint)
    {
        elapsed = 0;
        transform.position = startingPoint.position;
        direction = (Camera.main.ScreenToWorldPoint(mousePosition) - transform.position).normalized;
    }

    private void Update()
    {
        if (elapsed > destroyDelay)
        {
            ProjectilePool.Instance.ReturnProjectile(this);
        }
        else
        {
            elapsed += Time.deltaTime;
        }

        transform.Translate(direction * speed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyPool.Instance.ReturnEnemy(collision.gameObject.GetComponent<Enemy>());
            ProjectilePool.Instance.ReturnProjectile(this);
        }
    }

}
