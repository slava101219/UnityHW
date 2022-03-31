using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassageCars : MonoBehaviour
{
    [SerializeField] private GameObject _targetPoint;
    [SerializeField] private Spawner _spawner;
    [SerializeField] private int _speed;
    
    private int _secondsOfWaiting = 2;
    private int _xCoordinateTarget = 18;
    
    
    private void Start()
    {
        var spawnCar = StartCoroutine(Show());
    }

    private IEnumerator Show()
    {
        WaitForSeconds waitTime = new WaitForSeconds(_secondsOfWaiting);

        while (true)
        {
            Car car = _spawner.Spawn();
            StartCoroutine(Moving(car));
            yield return waitTime;
        }      
    }

    private IEnumerator Moving(Car car)
    {
        WaitForSeconds waitTime = new WaitForSeconds(_secondsOfWaiting); 

        while (car.transform.position.x > _xCoordinateTarget)
        {
            car.transform.position = Vector3.MoveTowards(car.transform.position, _targetPoint.transform.position, Time.deltaTime * _speed);          
            yield return null;
        }

        Destroy(car);
    }
}
