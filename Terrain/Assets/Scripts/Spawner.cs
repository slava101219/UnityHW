using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject[] _spawnPionts;

    public GameObject Spawn()
    {
        int spawnPointIndex = Random.Range(0, _spawnPionts.Length);
        return Instantiate(_prefab, _spawnPionts[spawnPointIndex].transform.position, _spawnPionts[spawnPointIndex].transform.rotation);
    }
}
