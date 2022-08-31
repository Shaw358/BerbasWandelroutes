using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleSpawner : MonoBehaviour
{
    [SerializeField] float timer;
    [SerializeField] float timerThreshold;

    [SerializeField] GameObject applePrefab;

    void Update()
    {
        if(timer < timerThreshold)
        {
            timer += Time.deltaTime;
        }
        else
        {
            timer = 0;
            GameObject newlySpawnedApple = Instantiate(applePrefab);
            newlySpawnedApple.transform.position = new Vector3(Random.Range(-5, 5), 10, Random.Range(-5, 5));
        }
    }
}