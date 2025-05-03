using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    public static CubeSpawner Instance;
    Queue<Cube> cubesQueue = new Queue<Cube>();
    [SerializeField] private int cubesQueueCapacity = 20;
    [SerializeField] private bool autoQueueGrow=true;
    [SerializeField] private GameObject cubePrefab;
    [SerializeField] private Color[] cubeColors;
    [HideInInspector] public int maxCubeNumber; // 4096 || 2^12
    private int maxPower = 12; // ^12
    private Vector3 defaultSpawnPosition;
    private void Awake()
    {
        Instance = this;
        defaultSpawnPosition  =transform.position;
        maxCubeNumber =(int) Mathf.Pow(2,maxPower);
        InitializeCubesQueue();


    }

    private void InitializeCubesQueue()
    {
        for (int i = 0; i < cubesQueueCapacity; i++)
        {
            //Add CubeToQueue();
        }
    }

    private void AddCubeToQueue()
    {
        //Cube cube = Instantiate(cubePrefab, defaultSpawnPosition, Quarternion.identity);
    }
}
