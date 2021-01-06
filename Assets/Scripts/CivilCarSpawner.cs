using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class CivilCarSpawner : MonoBehaviour
{
    public float carSpawnDelay = 2f;
    public GameObject civilCar;

    private float[] lanesArray;
    private float spawnDelay;

    private void Start()
    {
        lanesArray = new float[4];
        lanesArray[0] = -2.11f;
        lanesArray[1] = -0.76f;
        lanesArray[2] = 0.76f;
        lanesArray[3] = 2.11f;
        spawnDelay = carSpawnDelay;
    }

    private void Update()
    {
        spawnDelay -= Time.deltaTime;

        if (spawnDelay <= 0)
        {
            SpawnCar();
            spawnDelay = carSpawnDelay;
        }
    }

    private void SpawnCar()
    {
        int lane = Random.Range(0, 4);
        
        if (lane == 0 || lane == 1)
        {
            GameObject car = Instantiate(civilCar, new Vector3(lanesArray[lane], 6f, 0), Quaternion.Euler(new Vector3(0, 0, 180)));
            car.GetComponent<CivilCarBehaviour>().direction = 1;
            car.GetComponent<CivilCarBehaviour>().civilCarSpeed = 12;
        }

        if (lane == 2 || lane == 3)
        {
            Instantiate(civilCar, new Vector3(lanesArray[lane], 6f, 0), Quaternion.identity);
        }
    }
}
