using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private float startingRespawnTime = 5f;
    [SerializeField] private float decreaseRespawnTimeValue = 0.5f;
    [SerializeField] private float decreaseRespawnTimeEvery = 10f;
    [SerializeField] private int startingEnemyes = 5;
    private float respawnTime;
    private float elapsed = 0;
    private float secondElapsedTime = 0;
    bool startingSpawn = false;

    private void Start()
    {
        respawnTime = startingRespawnTime;
        startingSpawn = false;
        
    }
    private void Update()
    {
        if(!startingSpawn && elapsed > 0.1) 
        {
            for (int i = 0; i < startingEnemyes; i++)
            {
                SpawnEnemy();
            }
            startingSpawn = true;
        }
        
        
        elapsed += Time.deltaTime;
        secondElapsedTime += Time.deltaTime;
        if (elapsed > respawnTime)
        {
            elapsed = 0;
            SpawnEnemy();
        }

        if (secondElapsedTime > decreaseRespawnTimeEvery)
        {
            respawnTime -= decreaseRespawnTimeValue;
            secondElapsedTime = 0;
        }


    }

    private void SpawnEnemy()
    {
        Enemy newEnemy = EnemyPool.Instance.GetEnemy();
        Vector3 startingPosition = GetStartingPoisiton();
        newEnemy.transform.position = startingPosition;
    }

    private Vector3 GetStartingPoisiton()
    {
        int r = Random.Range(0, gameObject.transform.childCount);
        return gameObject.transform.GetChild(r).gameObject.transform.position;
    }
}
