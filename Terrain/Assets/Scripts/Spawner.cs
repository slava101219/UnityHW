using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Car _car;
    [SerializeField] private GameObject[] _spawnPionts;

    private int _interval = 2;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {   while (true)
        {
            int spawnPointIndex = Random.Range(0, _spawnPionts.Length);
            Instantiate(_car, _spawnPionts[spawnPointIndex].transform.position, _spawnPionts[spawnPointIndex].transform.rotation);
            yield return new WaitForSeconds(_interval);
        }       
    }
}
