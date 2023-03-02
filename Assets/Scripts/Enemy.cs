using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 1f;


    private void Update()
    {
        transform.Translate(x:0f, y: -speed * Time.deltaTime, z: 0f);
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
