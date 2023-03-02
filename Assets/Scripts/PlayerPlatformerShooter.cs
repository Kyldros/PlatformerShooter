using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerShooter : MonoBehaviour
{
    //[SerializeField] private float speed = 1f;
    [SerializeField] private GameObject shootPoint;
    [SerializeField] private float shootCooldown = 0.5f;
    private float elapsed = 0;

    private void Update()
    {
        //float horizontal = Input.GetAxis("Horizontal");
        //float vertical = Input.GetAxis("Vertical");

        //transform.Translate(x: horizontal * speed, y: 0f, z:0f);
        if (elapsed > shootCooldown) 
        {
            if (Input.GetMouseButtonDown(0))
            {
                Projectile newProjectile = ProjectilePool.Instance.GetProjectile();
                newProjectile.InizializeProjectile(Input.mousePosition, shootPoint.transform);
                elapsed = 0;
            }
        }
        else
        {
            elapsed += Time.deltaTime;
        }
       

    }

    
}
