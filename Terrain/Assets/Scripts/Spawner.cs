using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Car _car;
    [SerializeField] private GameObject[] _spawnPionts;

    public Car Spawn()
    {
        int spawnPointIndex = Random.Range(0, _spawnPionts.Length);
        return Instantiate(_car, _spawnPionts[spawnPointIndex].transform.position, _spawnPionts[spawnPointIndex].transform.rotation);
    }
}
