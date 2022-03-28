using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemonstratorCars : MonoBehaviour
{
    [SerializeField] private GameObject _prefab;
    [SerializeField] private GameObject _targetPoint;
    [SerializeField] private GameObject[] _spawnPionts;
    [SerializeField] private int _speed;
    
    private int _seconds = 2;
    private int _xCoordinateTarget = 18;
    
    
    private void Start()
    {
        var spawnCar = StartCoroutine(Demonstration());
    }

    private IEnumerator Demonstration()
    {
        WaitForSeconds _waitTime = new WaitForSeconds(_seconds);

        while (true)
        {
            int spawnPointIndex = Random.Range(0, _spawnPionts.Length);
            GameObject car = Instantiate(_prefab, _spawnPionts[spawnPointIndex].transform.position, _spawnPionts[spawnPointIndex].transform.rotation);

            while(car.transform.position != _targetPoint.transform.position)
            {
                car.transform.position = Vector3.MoveTowards(car.transform.position, _targetPoint.transform.position, Time.deltaTime*_speed);

                if (car.transform.position.x < _xCoordinateTarget)
                {
                    Destroy(car);
                }
                else
                {
                    yield return null;
                }               
            }

            yield return _waitTime;
        }      
    }
}
