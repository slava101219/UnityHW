using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerGrayCars : MonoBehaviour
{
    [SerializeField] private GameObject _prefabCar;
    [SerializeField] private GameObject _targetPoint;
    [SerializeField] private GameObject[] _spawnPionts;

    private static System.Random _random = new System.Random();
    private int _xCoordinateTarget = 18;
    
    private void Start()
    {
        var spawnCar = StartCoroutine(SpawnCars());
    }

    private IEnumerator SpawnCars()
    {      
        while (true)
        {
            int random = Random.Range(0, _spawnPionts.Length);
            GameObject enemy = Instantiate(_prefabCar, _spawnPionts[random].transform.position, _spawnPionts[random].transform.rotation);

            while(enemy.transform.position != _targetPoint.transform.position)
            {
                enemy.transform.position = Vector3.MoveTowards(enemy.transform.position, _targetPoint.transform.position, Time.deltaTime*10);

                if (enemy.transform.position.x < _xCoordinateTarget)
                {
                    Destroy(enemy);
                }
                else
                {
                    yield return null;
                }               
            }

            yield return new WaitForSeconds(2);
        }      
    }
}
