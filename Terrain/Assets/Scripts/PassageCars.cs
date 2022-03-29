using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassageCars : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject _targetPoint;
    [SerializeField] private GameObject[] _spawnPionts;
    [SerializeField] private int _speed;
    
    private int _seconds = 2;
    private int _xCoordinateTarget = 18;
    
    
    private void Start()
    {
        var spawnCar = StartCoroutine(Show());
    }

    private IEnumerator Show()
    {
        WaitForSeconds waitTime = new WaitForSeconds(_seconds);

        while (true)
        {
            GameObject car = Spawn(_prefab);
            StartCoroutine(Moving(car));
            yield return waitTime;
        }      
    }

    private GameObject Spawn(GameObject prefab)
    {
        int spawnPointIndex = Random.Range(0, _spawnPionts.Length);
        return Instantiate(prefab, _spawnPionts[spawnPointIndex].transform.position, _spawnPionts[spawnPointIndex].transform.rotation);
    }

    private IEnumerator Moving(GameObject car)
    {
        while (car.transform.position != _targetPoint.transform.position)
        {
            car.transform.position = Vector3.MoveTowards(car.transform.position, _targetPoint.transform.position, Time.deltaTime * _speed);

            if (car.transform.position.x < _xCoordinateTarget)
            {
                Destroy(car);
            }
            else
            {
                yield return null;
            }
        }
    }
}
