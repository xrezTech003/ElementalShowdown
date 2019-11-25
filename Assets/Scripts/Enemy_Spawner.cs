using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.MagicLeap;

public class Enemy_Spawner : MonoBehaviour
{
    public GameObject[] targetPrefabs;

    public GameObject Camera;

    public int range;

    private Transform[] targetEnemies;

    void Start()
    {
        targetEnemies = new Transform[10];

        for (int i = 0; i < 10; i++)
        {
            targetEnemies[i] = spawnEnemy();
        }
    }

    void Update()
    {
        for (int i = 0; i < 10; i++)
        {
            targetEnemies[i].LookAt(Camera.transform);
        }
    }

    private Transform spawnEnemy()
    {
        float x, y, z;
        float max = range * range;
        float headMax = 1.5f;

        int index = Mathf.RoundToInt(Random.value * targetPrefabs.Length - 1);

        y = Random.value * headMax;
        max -= y;
        y = Mathf.Sqrt(y);
        y = (Mathf.RoundToInt(Random.value) == 1) ? y : -y;

        x = Random.value * max;
        max -= x;
        x = Mathf.Sqrt(x);
        x = (Mathf.RoundToInt(Random.value) == 1) ? x : -x;

        z = max;
        z = Mathf.Sqrt(z);
        z = (Mathf.RoundToInt(Random.value) == 1) ? z : -z;

        return Instantiate(targetPrefabs[0].transform, new Vector3(x, y, z), Quaternion.identity);
    }
}
